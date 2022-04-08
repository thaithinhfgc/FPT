using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CustomValidator : FluentValidation.Resources.LanguageManager
    {
        public static class ErrorMessageKey
        {
            public const string ERROR_LOGIN_FAIL = "ERROR_LOGIN_FAIL";
            public const string ERROR_EXISTED = "ERROR_EXISTED";
            public const string ERROR_NOT_ALLOW_ACTION = "ERROR_NOT_ALLOW_ACTION";
            public const string ERROR_NOT_FOUND = "ERROR_NOT_FOUND";
            public const string ERROR_OLD_PASSWORD_NOT_CORRECT = "ERROR_OLD_PASSWORD_NOT_CORRECT";
            public const string ERROR_INVALID_FILE = "ERROR_INVALID_FILE";
            public const string ERROR_UPLOAD_FILE_FAILED = "ERROR_UPLOAD_FILE_FAILED";
            public const string ERROR_MIN_GREATER_MAX = "ERROR_MIN_GREATER_MAX";
            public const string ERROR_GREATER_ZERO = "ERROR_GREATER_ZERO";
            public const string ERROR_NOT_ENOUGH_QUANTITY = "ERROR_NOT_ENOUGH_QUANTITY";
            public const string ERROR_CART_EMPTY = "ERROR_CART_EMPTY";
            public const string ERROR_INVALID_ORDER = "ERROR_INVALID_ORDER";
            public const string ERROR_INVALID_QUANTITY = "ERROR_INVALID_QUANTITY";
            public const string ERROR_START_DATE = "ERROR_START_DATE";
            public const string ERROR_END_DATE = "ERROR_END_DATE";
            public static readonly string FILE_TOO_LARGE = "FILE_TOO_LARGE";
            public static readonly string FILE_WRONG_EXTENSION = "FILE_WRONG_EXTENSION";

        }

        public static class MessageKey
        {

            public const string MESSAGE_LOGIN_SUCCESS = "MESSAGE_LOGIN_SUCCESS";
            public const string MESSAGE_REGISTER_SUCCESS = "MESSAGE_REGISTER_SUCCESS";
            public const string MESSAGE_LOGOUT_SUCCESS = "MESSAGE_LOGOUT_SUCCESS";
            public const string MESSAGE_UPDATE_SUCCESS = "MESSAGE_UPDATE_SUCCESS";
            public const string MESSAGE_ADD_SUCCESS = "MESSAGE_ADD_SUCCESS";
            public const string MESSAGE_DELETE_SUCCESS = "MESSAGE_DELETE_SUCCESS";
            public const string MESSAGE_ORDER_SUCCESS = "MESSAGE_ORDER_SUCCESS";

        }
        public CustomValidator()
        {
            // EN


            // Error message
            // EN
            AddTranslation("en", ErrorMessageKey.ERROR_LOGIN_FAIL, "username or password is wrong");
            AddTranslation("en", ErrorMessageKey.ERROR_EXISTED, "is already exist");
            AddTranslation("en", ErrorMessageKey.ERROR_NOT_ALLOW_ACTION, "please login or action is not allow");
            AddTranslation("en", ErrorMessageKey.ERROR_NOT_FOUND, "is not found");
            AddTranslation("en", ErrorMessageKey.ERROR_OLD_PASSWORD_NOT_CORRECT, "password is wrong");
            AddTranslation("en", ErrorMessageKey.ERROR_INVALID_FILE, "file is invalid");
            AddTranslation("en", ErrorMessageKey.ERROR_UPLOAD_FILE_FAILED, "upload file failed");
            AddTranslation("en", ErrorMessageKey.ERROR_MIN_GREATER_MAX, "max price should be greater than min");
            AddTranslation("en", ErrorMessageKey.ERROR_GREATER_ZERO, "should be greater than 0");
            AddTranslation("en", ErrorMessageKey.ERROR_NOT_ENOUGH_QUANTITY, "is not enough in stock");
            AddTranslation("en", ErrorMessageKey.ERROR_CART_EMPTY, "cart is empty");
            AddTranslation("en", ErrorMessageKey.ERROR_INVALID_ORDER, "order is invalid");
            AddTranslation("en", ErrorMessageKey.ERROR_INVALID_QUANTITY, "have only");
            AddTranslation("en", ErrorMessageKey.ERROR_START_DATE, "Start Date should be at least tomorow");
            AddTranslation("en", ErrorMessageKey.ERROR_END_DATE, "End Date should be equal or greater than Start Date");
            AddTranslation("en", ErrorMessageKey.FILE_TOO_LARGE, "file is too large");
            AddTranslation("en", ErrorMessageKey.FILE_WRONG_EXTENSION, "file is wrong extension");

            // Success message
            // EN
            AddTranslation("en", MessageKey.MESSAGE_LOGIN_SUCCESS, "login success");
            AddTranslation("en", MessageKey.MESSAGE_REGISTER_SUCCESS, "register success");
            AddTranslation("en", MessageKey.MESSAGE_LOGOUT_SUCCESS, "logout success");
            AddTranslation("en", MessageKey.MESSAGE_UPDATE_SUCCESS, "update success");
            AddTranslation("en", MessageKey.MESSAGE_ADD_SUCCESS, "add success");
            AddTranslation("en", MessageKey.MESSAGE_DELETE_SUCCESS, "delete success");
            AddTranslation("en", MessageKey.MESSAGE_ORDER_SUCCESS, "order success");

            // Don't touch me please
            AddTranslation("en", "EmailValidator", "is not a valid email address");
            AddTranslation("en", "GreaterThanOrEqualValidator", "should be greater than or equal to {ComparisonValue}");
            AddTranslation("en", "GreaterThanValidator", "should be greater than {ComparisonValue}");
            AddTranslation("en", "LengthValidator", "should be between {MinLength} and {MaxLength} characters");
            AddTranslation("en", "MinimumLengthValidator", "should be at least {MinLength} characters");
            AddTranslation("en", "MaximumLengthValidator", "should be {MaxLength} characters or fewer");
            AddTranslation("en", "LessThanOrEqualValidator", "should be less than or equal to {ComparisonValue}");
            AddTranslation("en", "LessThanValidator", "should be less than {ComparisonValue}");
            AddTranslation("en", "NotEmptyValidator", "should not be empty");
            AddTranslation("en", "NotEqualValidator", "should not be equal to {ComparisonValue}");
            AddTranslation("en", "NotNullValidator", "should not be empty");
            AddTranslation("en", "RegularExpressionValidator", "is not in the correct format");
            AddTranslation("en", "EqualValidator", "should be equal to {ComparisonValue}");
            AddTranslation("en", "ExactLengthValidator", "should be equal to {ComparisonValue}");
            AddTranslation("en", "InclusiveBetweenValidator", "should be between {From} and {To}");
            AddTranslation("en", "ExclusiveBetweenValidator", "should be between {From} and {To} (exclusive)");
            AddTranslation("en", "NullValidator", "must be empty");
            AddTranslation("en", "EmptyValidator", "must be empty");
            AddTranslation("en", "EnumValidator", "has a range of values which does not include {PropertyValue}");
        }
    }
}
