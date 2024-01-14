namespace ConsoleApp1
{

    class Program
    {

        static void Main()
        {
            DataProcessor dataProcessor = new DataProcessor();

            DbDataProvider dbData = new DbDataProvider();

            dataProcessor.ProcessData(dbData);
        }
    }

    interface IDataProcessor
    {
        void ProcessData(IDataProvider dataProvider);
    }

    interface IDataProvider
    {
        string GetData();
    }

    class DataProcessor : IDataProcessor
    {
        public void ProcessData(IDataProvider dataProvider)
        {
            Console.WriteLine(dataProvider.GetData());
        }
    }

    class DbDataProvider : IDataProvider
    {
        public string GetData()
        {
            return "Data from db";
        }
    }

    class ApiDataProvider : IDataProvider
    {
        public string GetData()
        {
            return "Data from Api";
        }
    }

    class FileDataProvider : IDataProvider
    {
        public string GetData()
        {
            return "Data from file";
        }
    }

}