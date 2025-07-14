namespace MandrilAPI.Service;

public class DefaultsMessageUsers
{
    public const string MandrilNotFound = "El mandril no se ha encontrado o no existe. Verifique los datos e intente nuevamente.";
    public const string MandrilUpdateSucceeded = "El mandril se ha actualizado correctamente.";

    public const string SkillNotFound = "La habilidad no se ha encontrado o es inexistente en la base de datos";
    public const string SkillUpdateSucceeded = "La habilidad se ha actualizado correctamente.";

    public const string SkillAlreadyExists = "La habilidad ya existe. No se pueden crear Habilidades Duplicadas";

    public const string EntryInvalid = "Datos invalidos verifique que los campos no esten vacios o tengan minimo 3 caracteres sin espacios.";
    public const string EntryLenght = "Solo se permite un maximo de 25 caracteres.";

    public const string PotenciaInvalid = "La potencia inserida no debe ser mayor que 4";

    public const string DatabaseNull = "La informacion no se ha encontrado en la base de datos";

    public const string DeleteMandrilSucceeded = "El mandril se ha eliminado correctamente.";
    public const string DeleteSkillSucceeded = "La habilidad se ha eliminado correctamente.";
    public const string DeleteMandrilIsNotSucceeded = "No se ha podido eliminar el mandril.";
    public const string DeleteSkillIsNotSucceeded = "No se ha podido eliminar la Skill. Verifique los datos e intente nuevamente";
    public const string DeleteIsNotSucceeded = "No se han podido eliminar los datos. Puede ser que no existan o no se hallan encontrado en la base de datos.";

    public const string MandrilCreatedSuccessfully = "El mandril se ha creado correctamente.";
    public const string SkillCreatedSuccessfully = "La habilidad se ha creado correctamente.";

    public const string  AssingSkillToMandrilSucceeded = "Se ha asignado la habilidad ID  al mandril  correctamente.";
    public const string UpdatePowerOfSkillInMandrilSucceeded = "Se ha actualizado la potencia de la habilidad.";

    public const string RelationNotFound = "La relacion entre el mandril y la habilidad no se ha encontrado o no existe. Verifique los datos e intente nuevamente.";
    public const string RelationNotCreated_EntityNotFound = "No se ha podido generar una relacion entre el Mandril y la Habilidad  \n" +
            "Uno o mas elementos no existen en la base de datos.  ";

    public const string RelationNotCreated_EntityAlreadyExists = "No se ha podido generar una relacion entre Mandril y Skill. \n" +
           "La relacion ya existe en la base de datos.";

}