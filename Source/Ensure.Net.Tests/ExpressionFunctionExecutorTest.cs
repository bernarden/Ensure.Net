#if Expressions_Supported
using System;
using Vima.Ensure.Net.Tests.Helpers;
using Vima.Ensure.Net;
using System.Linq.Expressions;

namespace Vima.Ensure.Net.Tests
{
    [TestFixture]
    public class ExpressionFunctionExecutorTest
    {
        private const int IntTestValue = 86737765;

        [Test]
        public void ExecuteFunctionWithGenericValueInExpressionShouldThrowArgumentExceptionIfExpressionIsNull()
        {
            // Arrange
            IEnsurable<string> TestFuncToBeExecuted(string value, string parameterName) => new Ensurable<string>(parameterName);
            Expression<Func<string>> userInputExpression = null;
            IEnsurable<string> FuncToTest() => ExpressionFunctionExecutor.ExecuteFunctionWithGenericValueInExpression(userInputExpression, TestFuncToBeExecuted);

            // Act
            Exception ex = Assert.Throws<ArgumentException>(FuncToTest);

            // Assert
            Assert.Equal("Expression cannot be null.", ex.Message);
        }

        [Test]
        public void ExecuteFunctionWithGenericValueInExpressionShouldNotThrowArgumentExceptionIfExpressionHasNullPassedToIt()
        {
            // Arrange
            IEnsurable<string> TestFuncToBeExecuted(string value, string parameterName) => new Ensurable<string>(parameterName);
            Expression<Func<string>> userInputExpression = () => null;

            // Act
            IEnsurable<string> executeFunctionWithExpression = ExpressionFunctionExecutor.ExecuteFunctionWithGenericValueInExpression(userInputExpression, TestFuncToBeExecuted);

            // Assert
            Assert.Equal("Variable", executeFunctionWithExpression.Value);
        }

        [Test]
        public void ExecuteFunctionWithGenericValueInExpressionShouldThrowArgumentExceptionIfExpressionIsNotMemberExpression()
        {
            // Arrange
            IEnsurable<string> TestFuncToBeExecuted(string value, string parameterName) => new Ensurable<string>(parameterName);
            Expression<Func<string>> userInputExpression = () => string.Empty + string.Empty;
            IEnsurable<string> FuncToTest() => ExpressionFunctionExecutor.ExecuteFunctionWithGenericValueInExpression(userInputExpression, TestFuncToBeExecuted);

            // Act
            Exception ex = Assert.Throws<ArgumentException>(FuncToTest);

            // Assert
            Assert.Equal("Expression must be of type MemberExpression.", ex.Message);
        }

        [Test]
        public void ExecuteFunctionWithGenericValueInExpressionShouldNotThrowAnyExceptionIfExpressionTypeIsValid()
        {
            // Arrange
            string variableToCheck = "MyVariable";
            IEnsurable<string> TestFuncToBeExecuted(string value, string parameterName) => new Ensurable<string>(parameterName);
            Expression<Func<string>> userInputExpression = () => variableToCheck;

            // Act
            IEnsurable<string> executeFunctionWithExpression = ExpressionFunctionExecutor.ExecuteFunctionWithGenericValueInExpression(userInputExpression, TestFuncToBeExecuted);

            // Assert
            Assert.Equal(nameof(variableToCheck), executeFunctionWithExpression.Value);
        }


        [Test]
        public void ExecuteFunctionWithNullableStructInExpressionShouldThrowArgumentExceptionIfExpressionIsNull()
        {
            // Arrange
            IEnsurable<int> TestFuncToBeExecuted(int? value, string parameterName) => new Ensurable<int>(IntTestValue);
            Expression<Func<int?>> userInputExpression = null;
            IEnsurable<int> FuncToTest() => ExpressionFunctionExecutor.ExecuteFunctionWithNullableStructInExpression(userInputExpression, TestFuncToBeExecuted);

            // Act
            Exception ex = Assert.Throws<ArgumentException>(FuncToTest);

            // Assert
            Assert.Equal("Expression cannot be null.", ex.Message);
        }

        [Test]
        public void ExecuteFunctionWithNullableStructInExpressionShouldNotThrowArgumentExceptionIfExpressionHasNullPassedToIt()
        {
            // Arrange
            IEnsurable<int> TestFuncToBeExecuted(int? value, string parameterName) => new Ensurable<int>(IntTestValue);
            Expression<Func<int?>> userInputExpression = () => null;

            // Act
            IEnsurable<int> executeFunctionWithExpression = ExpressionFunctionExecutor.ExecuteFunctionWithNullableStructInExpression(userInputExpression, TestFuncToBeExecuted);

            // Assert
            Assert.Equal(IntTestValue, executeFunctionWithExpression.Value);
        }

        [Test]
        public void ExecuteFunctionWithNullableStructInExpressionShouldThrowArgumentExceptionIfExpressionIsNotMemberExpression()
        {
            // Arrange
            IEnsurable<int> TestFuncToBeExecuted(int? value, string parameterName) => new Ensurable<int>(IntTestValue);
            Expression<Func<int?>> userInputExpression = () => 5 + 5;
            IEnsurable<int> FuncToTest() => ExpressionFunctionExecutor.ExecuteFunctionWithNullableStructInExpression(userInputExpression, TestFuncToBeExecuted);

            // Act
            Exception ex = Assert.Throws<ArgumentException>(FuncToTest);

            // Assert
            Assert.Equal("Expression must be of type MemberExpression.", ex.Message);
        }

        [Test]
        public void ExecuteFunctionWithNullableStructInExpressionShouldNotThrowAnyExceptionIfExpressionTypeIsValid()
        {
            // Arrange
            int? variableToCheck = IntTestValue;
            IEnsurable<int> TestFuncToBeExecuted(int? value, string parameterName) => new Ensurable<int>(IntTestValue);
            Expression<Func<int?>> userInputExpression = () => variableToCheck;

            // Act
            IEnsurable<int> executeFunctionWithExpression = ExpressionFunctionExecutor.ExecuteFunctionWithNullableStructInExpression(userInputExpression, TestFuncToBeExecuted);

            // Assert
            Assert.Equal(variableToCheck, executeFunctionWithExpression.Value);
        }
    }
}
#endif