using System.ComponentModel.DataAnnotations;

namespace LocalDataService
{
    public class DataModel<T> :  IDataModel  where T : new()
    {
        private readonly JsonManager<T> _jsonManager;
        public DataModel(string dataName)
        {
            DataName = dataName;
            _jsonManager = new JsonManager<T>();
            Data = _jsonManager.DeSerializ(dataName);
            DataType = typeof(T);
        }

        public string DataName { get; set; }
        public T Data { get; set; }
        public Type DataType { get ; set; }



        public object GetData()
        {
            return Data;
        }

        public void SetData()
        {
            _jsonManager.Serializ(Data, DataName);
        }
    }
}
