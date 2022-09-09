using NewLife.Log;
using NewLife.Net;
using NewLife.Security;

namespace Test
{
    internal class Program
    {
        private static void Main(String[] args)
        {
            //MachineInfo.RegisterAsync();
            XTrace.UseConsole();

            XTrace.Log.Level = LogLevel.Debug;

            //Console.Write("输出要执行的测试方法序号：");
            //var idx = Console.ReadLine().ToInt();

            try
            {
                Test1();
                //var mi = typeof(Program).GetMethod("Test" + idx, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                //if (mi != null) mi.Invoke(null, null);
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
            }

            Console.WriteLine("OK");
            Console.Read();
        }

        private static void Test1()
        {

        }
    }
}
