namespace MandrilAPI.Aplication.Service;

public class MessageDefaultsUsers
{
   
    // -------- General errors --------
    public const string EntryInvalid =
        "Invalid data. Please verify that fields are not empty and have at least 3 characters without spaces.";
    public const string EntryMaxLength = "Maximum of 25 characters allowed.";
    public const string EntryMinLength = "Only letters are allowed, minimum of 3 characters.";
    public const string PowerInvalid =
        "The entered power must not be greater than 4.";
    public const string EmailInvalid = "Email is invalid";
    public const string NullObject = "The information field is null.";

    // -------- Not found --------
    public const string RelationNotFound =
        "The relationship between the mandrill and skill was not found or does not exist. Please verify the data and try again.";
     public const string UserNotFound = "The user could not be found.";

    // -------- Already exist --------
    public const string EmailAlreadyExist =
        "The email is already used";
   
    public const string PublicUsernameAlreadyExist =
        "The username already exist.";

    // -------- Deletion --------
    public const string DeleteSkillSucceeded =
        "The skill has been successfully deleted.";
    

    // -------- Updates --------
    
    public const string FirstNameUpdateSucceeded = "The first name has been updated.";
    public const string LastNameUpdateSucceeded = "The Lastname has been updated.";
    public const string PublicUserNameUpdateSucceeded = "The username has been updated.";
    public const string PasswordUpdateSucceeded = "The password has been updated.";

    // -------- Messages Authentication --------
   
    public const string PasswordUpdateError = "The password could not be updated. Please verify the data and try again.";
    public const string PasswordMismatch = "The passwords do not match. Please verify the data and try again.";
    public const string PasswordTooShort = "The password must be at least 6 characters long.";
    public const string PasswordWrong = "The password is wrong";
    public const string RegistrationSucceeded = "You are has been successfully registered.";
   
}