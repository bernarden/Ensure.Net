properties {

  $MainDirectory = Resolve-Path ..
  $SourceDirectory = "$MainDirectory\Source"
  $TempDirectory = "$MainDirectory\Temp"
  $SolutionFilePath = "$SourceDirectory\Vima.Ensure.Net.sln"

  $NugetFilePath = "$TempDirectory\nuget.exe"
  $NugetFileUrl = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"

  $NugetPackages = @(
    @{"Name" = "vswhere"; "Version" = "2.7.1"; "Alias" = "VSWhere"; "ExePath" = "tools/vswhere.exe" },
    @{"Name" = "NUnit.ConsoleRunner"; "Version" = "3.10.0"; "Alias" = "NUnitConsole"; "ExePath" = "tools/nunit3-console.exe" }
  )

  $TestsConfig = @(
    @{"Framework" = "net35"; "TestingFramework" = "net-3.5"; "Utility" = "NUnit"; },
    @{"Framework" = "net452"; "TestingFramework" = "net-4.5"; "Utility" = "NUnit"; },   
    @{"Framework" = "netcoreapp2.2"; "TestingFramework" = "netcoreapp2.2"; "Utility" = "DotnetTest"; }
    @{"Framework" = "netcoreapp3.0"; "TestingFramework" = "netcoreapp3.0"; "Utility" = "DotnetTest"; }
  )
}

task default -depends PrepareTools, Restore, Clean, Build, Test, NugetPackage

task PrepareTools {
  if (!(Test-Path $TempDirectory)) {
    New-Item $TempDirectory -type directory > $null
  }

  DownloadNugetFile

  DownloadNugetPackagesAndSetAliases
  
  SetMSBuildAlias
}

task Clean {
  exec { MSBuild "/t:clean" "/p:Configuration=Release" $SolutionFilePath /m }
}

task Restore {
  exec { MSBuild "/t:restore" "/p:Configuration=Release" $SolutionFilePath /m }
}

task Build {
  exec { MSBuild "/t:build" "/p:Configuration=Release" $SolutionFilePath /m "/p:TreatWarningsAsErrors=`"true`"" }
}

task Test { 
  Push-Location $SourceDirectory
  $TestDlls = Get-ChildItem "*\bin\Release\*" -Recurse | Where-Object { $_.Name -match ".*tests?\.dll" }
  foreach ($TestDll in $TestDlls) {
    Push-Location $($TestDll.DirectoryName)
    $TestConfig = $TestsConfig | Where-Object { $_.Framework -eq $TestDll.Directory.Name }
    if ($TestConfig.Utility -eq "NUnit") {
      exec { NUnitConsole  $TestDll.Name --framework $TestConfig.TestingFramework }
    }
    else {
      $ProjectFilePath = Get-ChildItem "$($TestDll.Directory.Parent.Parent.Parent.FullName)\*" | Where-Object { $_.Name -match ".*tests?\.csproj" } | Select-Object -First 1
      exec { dotnet test $ProjectFilePath -f "$($TestConfig.TestingFramework)" -c Release --no-build }
    }
    Pop-Location
    Write-Host ("-" * 70)
  }
  Pop-Location
}

task NugetPackage {
  exec { MSBuild "/t:pack" "/p:IncludeSource=true" "/p:SymbolPackageFormat=snupkg" "/p:Configuration=Release" "$SourceDirectory\Vima.Ensure.Net\Vima.Ensure.Net.csproj" }
}

function DownloadNugetFile() {
  if (!(Test-Path $NugetFilePath)) {
    Write-Host "Downloading Nuget file." -foregroundcolor Green
    (New-Object System.Net.WebClient).DownloadFile($NugetFileUrl, $NugetFilePath)
  }
}

function DownloadNugetPackagesAndSetAliases() {
  foreach ($Package in $NugetPackages) {
    $PackageFolder = "$TempDirectory\$($Package.Name).$($Package.Version)"
    if (!(Test-Path $PackageFolder)) {
      Write-Host ("-" * 70)
      Write-Host "Downloading $($Package.Name) package." -foregroundcolor Green
      exec { & $NugetFilePath install $Package.Name -OutputDirectory $TempDirectory -Version $Package.Version }
    }
    if ($Package.Alias -and $Package.ExePath -and (Test-Path "$PackageFolder\$($Package.ExePath)") ) {
      Set-Alias "$($Package.Alias)" "$PackageFolder\$($Package.ExePath)" -Scope Script
    }
  }
}

function SetMSBuildAlias() {
  $path = vswhere -latest -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe | select-object -first 1
  if ($path) {
    Set-Alias MSBuild $path -Scope Script
  }
  else {
    throw "MSBuild is not found. Please install VS2017 or later."
  }
}

