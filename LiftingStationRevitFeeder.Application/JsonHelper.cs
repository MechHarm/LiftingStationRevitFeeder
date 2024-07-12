namespace LiftingStationRevitFeeder.Application
{
    public static class JsonHelper<T> where T : new()
    {
        public static void WriteToJsonFile(string filePath, T objectToWrite, bool append = false)
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = Newtonsoft.Json.JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
