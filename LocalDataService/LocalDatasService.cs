namespace LocalDataService
{
    public class LocalDatasService : IDisposable
    {

        private readonly Dictionary<Type, object> _datas;
        private readonly List<IDataModel> _datasAccess;

        public LocalDatasService()
        {
            _datasAccess = new DataRepasitory().DataModels;
            _datas = new Dictionary<Type, object>();
            DeserializDatas();
        }



        public T  Get<T>()
        {
            if (!_datas.ContainsKey(typeof(T)))
                throw (new Exception("Тhere is no such data in the local storage"));
            return (T)_datas[typeof(T)];
        }


        public void Dispose()
        {
            SerializDatas();
        }

        private void SerializDatas()
        {
            foreach (var dataAccess in _datasAccess)
            {
                dataAccess.SetData();
            }
        }

        private void DeserializDatas()
        {
            foreach (var dataAccess in _datasAccess)
            {
                _datas.Add(dataAccess.DataType, dataAccess.GetData());
            }
        }
    }
}
