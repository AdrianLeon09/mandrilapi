namespace MandrilAPI.Service
{
    public static class MessageDefaultsDevs
    {   
        // General errors
        public const string DatabaseNotFound = "The information was not found in the database.";
        public const string ReturnedObjectIsNull = "The returned object {EntityType} is null.";
        public const string InvalidEntry = "Invalid data. Please verify that fields are not empty and have at least 3 characters.";

        // Not found
        public const string MandrilNotFound = "The Mandril object with ID {EntityID} was not found or does not exist.";
        public const string AllMandrilsNotFound = "No Mandril objects were found";
        public const string AllSkillsNotFound = "No Skill objects were found";
        public const string SkillNotFound = "The skill with ID {EntityID} was not found or does not exist.";
        public const string SkillsNotFound = "No skills were found.";
        

        // Deletion
        public const string DeleteError = "Unable to delete the data. Verify that the information exists or is accessible.";
        public const string DeleteSuccess = "The data has been successfully deleted.";

        // Successful queries
        public const string AllMandrilsRetrieved = "All mandrils have been successfully retrieved.";
        public const string AllSkillsRetrieved = "All skills have been successfully retrieved.";
        public const string MandrilWithSkillRetrieved = "The mandril with ID {targetMandrilId} and skill with ID {targetSkillId} have been successfully retrieved.";
        public const string MandrilWithAllSkillsRetrieved = "The mandril with ID {targetMandrilId} and all its skills have been successfully retrieved.";
        public const string AllMandrilsWithSkillsRetrieved = "All mandrils with their skills have been successfully retrieved.";

        // Failed queries
        public const string AllMandrilsWithSkillsError = "Unable to retrieve mandrils with their skills. Verify that the information exists or is accessible.";
        public const string MandrilWithSkillsNotFound = "No skills associated with this mandril were found.";
        public const string MandrilsWithSkillsNotFound = "No mandrils with skills were found in the database.";

        // Relationships
        public const string RelationCreated = "A relationship has been created between Skill ID: {EntitySkillID} and Mandril ID: {EntityMandrilID}.\n" +
            "The skill power for the mandril has been set to default values = {PotenciaMH}";
        public const string RelationCreationEntityNotFound = "Unable to create a relationship between Mandril ID: {EntityMandril} and Skill ID: {EntitySkill}.\n" +
            "One or more elements do not exist in the database.";
         public const string RelationMandrilWithSkillNotFound = "Skill ID {targetSkillId} related to the specified mandril ID {targetMandrilId} was not found.";
        public const string RelationAlreadyExists = "Unable to create a relationship between Mandril ID: {EntityMandril} and Skill ID: {EntitySkill}.\n" +
            "The relationship already exists in the database.";

        // Updates
        public const string SkillUpdateSuccess = "The skill with ID {EntitySkillID} has been successfully updated.";
        public const string MandrilUpdateSuccess = "The mandril with ID {EntityMandrilID} has been successfully updated.";
        public const string UpdateError = "Unable to update object with ID {EntityID}. Verify that the information exists or that data requirements are met.";
        public const string RelationUpdateError = "Unable to update the power of skill {EntitySkillID} for mandril {EntityMandrilID}. Verify that the information exists or that data types match.";
        public const string SkillPowerUpdateSuccess = "The power of skill {EntitySkillID} for mandril {EntityMandrilID} has been successfully updated. The new value is {EntityPower}";

        // Creation
        public const string MandrilCreated = "The mandril has been successfully created.";
        public const string SkillCreated = "The skill has been successfully created.";
        public const string MandrilCreationError = "Unable to create the mandril in the database. Verify if the data meets the requirements.";
        public const string SkillCreationError = "Unable to create the skill in the database. Verify if the data meets the requirements.";
    }
}
