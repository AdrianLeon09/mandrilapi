namespace MandrilAPI.Aplication.Service;

public static class MessageDefaultsUsers
{
    // General errors
    public const string EntryInvalid =
        "Invalid data. Please verify that fields are not empty and have at least 3 characters without spaces.";
    public const string EntryMaxLength = "Maximum of 25 characters allowed.";
    public const string EntryMinLength = "Only letters are allowed, minimum of 3 characters.";
    public const string PowerInvalid =
        "The entered power must not be greater than 4.";
    public const string EmailInvalid = "Email is invalid";

    // Not found
    public const string MandrilNotFound =
        "The mandrill was not found or does not exist. Please verify the data and try again.";
    public const string SkillNotFound =
        "The skill was not found or does not exist in the database.";
    public const string DataBaseNotFound =
        "The information was not found in the database.";
    public const string RelationNotFound =
        "The relationship between the mandrill and skill was not found or does not exist. Please verify the data and try again.";
    public const string RelationMandrilWithSkillAndUserNotFound = "Skill ID related to the specified mandril and User was not found.";

    // Deletion
    public const string DeleteMandrilSucceeded =
        "The mandrill has been successfully deleted.";
    public const string DeleteMandrilIsNotSucceeded =
        "Unable to delete the mandrill.";
    public const string DeleteSkillSucceeded =
        "The skill has been successfully deleted.";
    public const string DeleteSkillError =
        "Unable to delete the skill. Please verify the data and try again.";
    public const string DeleteNotSucceeded =
        "Unable to delete the data. It may not exist or was not found in the database.";

    // Successful queries
    public const string MandrilCreatedSuccess =
        "The mandrill has been successfully created.";
    public const string SkillCreatedSuccess =
        "The skill has been successfully created.";
    public const string AssingSkillToMandrilSucceeded =
        "The skill has been successfully assigned to the mandrill.";
  

    // Failed queries
    public const string SkillAlreadyExists =
        "The skill already exists. Duplicate skills cannot be created.";

    // Relationships
    public const string RelationCreationEntityNotFound =
        "Unable to create a relationship between the mandrill and the skill. " +
        "One or more elements do not exist in the database.";
    public const string RelationAlreadyExists =
        "Unable to create a relationship between the mandrill and the skill. " +
        "The relationship already exists in the database.";

    // Updates

 public const string SkillUpdateSucceeded =
        "The skill has been successfully updated.";
    public const string MandrilUpdateSucceeded =
          "The mandrill has been successfully updated.";
  public const string SkillPowerUpdateSuccess =
        "The skill power has been updated.";

    // -------- Messages Authentication --------
    public const string UserNotFound = "The user could not be found.";
    
    
    public const string FirstNameUpdateSucceeded = "The first name has been updated.";
    public const string LastNameUpdateSucceeded = "The Lastname has been updated.";
    public const string PublicUserNameUpdateSucceeded = "The username has been updated.";
    
    public const string PublicUsernameAlreadyExists =
        "The username already exists.";

    public const string PasswordUpdateSucceeded = "The password has been updated.";
    public const string PasswordUpdateError = "The password could not be updated. Please verify the data and try again.";
    public const string PasswordMismatch = "The passwords do not match. Please verify the data and try again.";
    public const string PasswordTooShort = "The password must be at least 6 characters long.";

    public const string RegistrationSucceeded = "You are has been successfully registered.";


}