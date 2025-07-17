namespace MandrilAPI.Service;

public static class MessageDefaultsUsers
{
    // General errors
    public const string EntryInvalid =
        "Invalid data. Please verify that fields are not empty and have at least 3 characters without spaces.";
    public const string EntryLength =
        "Maximum of 25 characters allowed.";
    public const string PowerInvalid =
        "The entered power must not be greater than 4.";

    // Not found
    public const string MandrilNotFound =
        "The mandrill was not found or does not exist. Please verify the data and try again.";
    public const string SkillNotFound =
        "The skill was not found or does not exist in the database.";
    public const string DataBaseNotFound =
        "The information was not found in the database.";
    public const string RelationNotFound =
        "The relationship between the mandrill and skill was not found or does not exist. Please verify the data and try again.";

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

    // Creation
    // (Already included in Successful queries: MandrilCreatedSuccessfully, SkillCreatedSuccessfully)
}