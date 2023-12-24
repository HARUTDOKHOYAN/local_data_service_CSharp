namespace LocalDataService
{
    public interface IDataModel
    {
        string DataName { get; set; }
        Type DataType { get; set; }
        object GetData();
        void SetData();
    }
}
