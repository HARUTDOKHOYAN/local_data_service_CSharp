using LocalDataService;


var localDataService = new LocalDatasService();


var a = localDataService.Get<List<DataB>>();

a.Add(new DataB());

localDataService.Dispose();