namespace MandrilAPI.Service;

public static class MessageDefaultsUsers
{
    // Errores generales
    public const string EntryInvalid =
        "Datos inválidos. Verifique que los campos no estén vacíos y tengan al menos 3 caracteres sin espacios.";
    public const string EntryLength =
        "Solo se permite un máximo de 25 caracteres.";
    public const string PotenciaInvalid =
        "La potencia ingresada no debe ser mayor que 4.";

    // No encontrados
    public const string MandrilNotFound =
        "El mandril no se ha encontrado o no existe. Verifique los datos e intente nuevamente.";
    public const string SkillNotFound =
        "La habilidad no se ha encontrado o no existe en la base de datos.";
    public const string DatabaseNull =
        "La información no se ha encontrado en la base de datos.";
    public const string RelationNotFound =
        "La relación entre el mandril y la habilidad no se ha encontrado o no existe. Verifique los datos e intente nuevamente.";

    // Eliminación
    public const string DeleteMandrilSucceeded =
        "El mandril se ha eliminado correctamente.";
    public const string DeleteMandrilIsNotSucceeded =
        "No se ha podido eliminar el mandril.";
    public const string DeleteSkillSucceeded =
        "La habilidad se ha eliminado correctamente.";
    public const string DeleteSkillIsNotSucceeded =
        "No se ha podido eliminar la habilidad. Verifique los datos e intente nuevamente.";
    public const string DeleteIsNotSucceeded =
        "No se han podido eliminar los datos. Puede que no existan o no se hayan encontrado en la base de datos.";

    // Consultas exitosas
    public const string MandrilCreatedSuccessfully =
        "El mandril se ha creado correctamente.";
    public const string SkillCreatedSuccessfully =
        "La habilidad se ha creado correctamente.";
    public const string AssingSkillToMandrilSucceeded =
        "Se ha asignado la habilidad al mandril correctamente.";
  

    // Consultas fallidas
    public const string SkillAlreadyExists =
        "La habilidad ya existe. No se pueden crear habilidades duplicadas.";

    // Relaciones
    public const string RelationNotCreated_EntityNotFound =
        "No se ha podido generar una relación entre el mandril y la habilidad. " +
        "Uno o más elementos no existen en la base de datos.";
    public const string RelationNotCreated_EntityAlreadyExists =
        "No se ha podido generar una relación entre el mandril y la habilidad. " +
        "La relación ya existe en la base de datos.";

    // Actualizaciones
    // (Ya incluidas en Consultas exitosas: MandrilUpdateSucceeded, SkillUpdateSucceeded, UpdatePowerOfSkillInMandrilSucceeded)
 public const string SkillUpdateSucceeded =
        "La habilidad se ha actualizado correctamente.";
    public const string MandrilUpdateSucceeded =
          "El mandril se ha actualizado correctamente.";
  public const string UpdatePowerOfSkillInMandrilSucceeded =
        "Se ha actualizado la potencia de la habilidad.";

    // Creación
    // (Ya incluidas en Consultas exitosas: MandrilCreatedSuccessfully, SkillCreatedSuccessfully)
}