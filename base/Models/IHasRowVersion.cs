namespace Solo.Base
{
    public interface IHasRowVersion
    {
        byte[] RowVersion {get;set;}
    }
}