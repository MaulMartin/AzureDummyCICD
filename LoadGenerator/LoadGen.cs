using System;
using System.Net.Http;

namespace LoadGenerator
{
    public static class LoadGen
    {
        public static int AttemptsCount = 10;
        public static int TimeoutSpanSec = 0;
        public static bool RandomTimeouts = false;
        public static int BottomLimitRandTimeout = 0;
        public static int TopLimitRandTimeout = 0;

        public static async void GenereateLoad()
        {
            Console.WriteLine("Start!");

            var rnd = new Random();
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

                    Console.WriteLine($"Request #{i} status: {res.StatusCode}");

                    if (RandomTimeouts)
                    {
                        System.Threading.Thread.Sleep(rnd.Next(BottomLimitRandTimeout, TopLimitRandTimeout) * 1000);
                    }
                    else
                    {
                        if (TimeoutSpanSec > 0)
                        {
                            System.Threading.Thread.Sleep(TimeoutSpanSec * 1000);
                        }
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


