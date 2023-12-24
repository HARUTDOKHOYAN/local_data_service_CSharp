namespace LocalDataService
{
    public class DataRepasitory
    {

        public DataRepasitory()
        {
            DataModels = new List<IDataModel>();
            RegisterRepasitory();
        }

        public  List<IDataModel> DataModels { get; private set; }

        private void RegisterRepasitory()
        {
            AddData<List<DataA>>("DataPresets");
            AddData<List<DataB>>("DataResent");
            AddData<List<DataC>>("DataColor");
            AddData<DataA>("CountEditor");
        }
        private void AddData<T>(string dataName) where T :  new()
        {
            DataModels.Add(new DataModel<T>(dataName));
        }
    }
}
