using System;
using System.Net.Http;

namespace LoadGenerator
{
    public static class LoadGen
    {
        public static int AttemptsCount = 10;
        public static int TimeoutSpanSec = 0;

        public static async void GenereateLoad()
        {
            int failCount = 0;
            int succCount = 0;

            try
            {
                for (int i = 1; i <= AttemptsCount; i++)
                {
                    HttpResponseMessage res;

                    using (var client = new HttpClient())
                    using (HttpResponseMessage response = await client.GetAsync("https://dummycicd.azurewebsites.net/api/test").ConfigureAwait(false))
                    {
                        res = response;
                    }

                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        succCount++;
                    }
                    else
                    {
                        failCount++;
                    }

                    Console.WriteLine($"Reques #{i} status: {res.StatusCode}");

                    if(TimeoutSpanSec > 0)
                    {
                        System.Threading.Thread.Sleep(TimeoutSpanSec * 1000);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Succesful requests count: {succCount}");
            Console.WriteLine($"Failed requests count: {failCount}");
        }
    }
}


