namespace MandrilAPI.Service
{
    public static class MessageDefaultsDevs
    {
        // Errores generales
        public const string DatabaseNotFound = "La información no se ha encontrado en la base de datos.";
        public const string ReturnedObjectIsNull = "El objeto devuelto {EntityType} es null.";
        public const string InvalidEntry = "Datos inválidos. Verifique que los campos no estén vacíos o tengan mínimo 3 caracteres.";

        // No encontrados
        public const string MandrilNotFound = "El objeto de tipo Mandril con ID {EntityID} no se ha encontrado o no existe.";
        public const string AllMandrilsNotFound = "No se han encontrado objetos de tipo Mandril";
        public const string AllSkillsNotFound = "No se han encontrado objetos de tipo Skill";
        public const string SkillNotFound = "La habilidad con ID {EntityID} no se ha encontrado o no existe.";
        public const string SkillsNotFound = "No se han encontrado habilidades.";
        

        // Eliminación
        public const string DeleteError = "No se han podido eliminar los datos. Verifique que la información exista o sea accesible.";
        public const string DeleteSuccess = "Los datos han sido eliminados exitosamente.";

        // Consultas exitosas
        public const string AllMandrilsRetrieved = "Se han obtenido todos los mandriles exitosamente.";
        public const string AllSkillsRetrieved = "Se han obtenido todas las habilidades exitosamente.";
        public const string MandrilWithSkillRetrieved = "Se ha obtenido el mandril con ID {targetMandrilId} y la habilidad con ID {targetSkillId} exitosamente.";
        public const string MandrilWithAllSkillsRetrieved = "Se ha obtenido el mandril con ID {targetMandrilId} y todas sus habilidades exitosamente.";
        public const string AllMandrilsWithSkillsRetrieved = "Se han obtenido todos los mandriles con sus habilidades exitosamente.";

        // Consultas fallidas
        public const string AllMandrilsWithSkillsError = "No se han podido obtener los mandriles con sus habilidades. Verifique que la información exista o sea accesible.";
        public const string MandrilWithSkillsNotFound = "No se han encontrado habilidades asociadas a este mandril.";
        public const string MandrilsWithSkillsNotFound = "No se han encontrado mandriles con habilidades en la base de datos.";

        // Relaciones
        public const string RelationCreated = "Se ha generado una relación entre Skill ID: {EntitySkillID} y Mandril ID: {EntityMandrilID}.\n" +
            "La potencia de la habilidad para el mandril se ha establecido en los valores por defecto = {PotenciaMH}";
        public const string RelationCreationEntityNotFound = "No se ha podido generar una relación entre Mandril ID: {EntityMandril} y Skill ID: {EntitySkill}.\n" +
            "Uno o más elementos no existen en la base de datos.";
         public const string RelationMandrilWithSkillNotFound = "No se ha encontrado una habilidad ID {targetSkillId} relacionada al mandril ID {targetMandrilId} especificado.";
        public const string RelationAlreadyExists = "No se ha podido generar una relación entre Mandril ID: {EntityMandril} y Skill ID: {EntitySkill}.\n" +
            "La relación ya existe en la base de datos.";

        // Actualizaciones
        public const string SkillUpdateSuccess = "Se ha actualizado la habilidad con ID {EntitySkillID} exitosamente.";
        public const string MandrilUpdateSuccess = "Se ha actualizado el mandril con ID {EntityMandrilID} exitosamente.";
        public const string UpdateError = "No se ha podido actualizar el objeto con ID {EntityID}. Verifique que la información exista o que los requisitos de datos se cumplan.";
        public const string RelationUpdateError = "No se ha podido actualizar la potencia de la habilidad {EntitySkillID} en el mandril {EntityMandrilID}. Verifique que la información exista o que los tipos de datos coincidan.";
        public const string SkillPowerUpdateSuccess = "Se ha actualizado la potencia de la habilidad {EntitySkillID} en el mandril {EntityMandrilID} exitosamente. El nuevo valor es {EntityPower}";

        // Creación
        public const string MandrilCreated = "El mandril se ha creado correctamente.";
        public const string SkillCreated = "La habilidad se ha creado correctamente.";
        public const string MandrilCreationError = "No se ha podido crear el mandril en la base de datos. Verifique si los datos cumplen los requisitos.";
        public const string SkillCreationError = "No se ha podido crear la habilidad en la base de datos. Verifique si los datos cumplen los requisitos.";
    }
}
