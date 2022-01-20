using System;

namespace Final_Odev
{
    class Program
    {
        static void Main(string[] args)
        {
            String quit;
            String HomeTeam;
            String AwayTeam;
            float FTHomeGol;
            float FTAwayGol;
            float AwayShot;
            float HomeShot;
            float AwayCorner;

            while (true) //Kullanıcı programa "cikis" yazana kadar döngüyü devam ettiriyor.
            {
                Console.WriteLine("******************Skor Tahmin Etme Programi******************");
            
            startHomeTeam: 
                Console.Write("Ev Sahibi takimi girin: ");
                HomeTeam = Console.ReadLine(); //HomeTeam için kullancıdan veri alıyoruz.

                if (HomeTeam == "" || HomeTeam == " ")
                {
                    Console.WriteLine("Bos veri girilemez!");
                    goto startHomeTeam; //Eğer boş veri girerse başa dönmesi için goto kullandık.
                }

            startAwayTeam:
                Console.Write("Rakip takimi girin: ");
                AwayTeam = Console.ReadLine(); //AwayTeam için kullancıdan veri alıyoruz.

                if (AwayTeam == "" || AwayTeam == " ")
                {
                    Console.WriteLine("Bos veri girilemez!");
                    goto startAwayTeam; //Eğer boş veri girerse başa dönmesi için goto kullandık.
                }

            startFTHomeGol:
                Console.Write("Ev sahibi takimin attigi toplam gol sayisi: ");
                FTHomeGol = float.Parse(Console.ReadLine()); //FTHomeGol için kullancıdan veri alıyoruz.

                if (FTHomeGol < 0)
                {
                    Console.WriteLine("Sayi negatif olamaz!");
                    goto startFTHomeGol; //Eğer negatif bir deger girerse başa dönmesi için goto kullandık.
                }

            startFTAwayGol:
                Console.Write("Rakip takimin attigi toplam gol sayisi: ");
                FTAwayGol = float.Parse(Console.ReadLine()); //FTAwayGol için kullancıdan veri alıyoruz.

                if (FTAwayGol < 0)
                {
                    Console.WriteLine("Sayi negatif olamaz!");
                    goto startFTAwayGol; //Eğer negatif bir deger girerse başa dönmesi için goto kullandık.
                }

            startHomeShot:
                Console.Write("Ev sahibi takimin attigi sut sayisi: ");
                HomeShot = float.Parse(Console.ReadLine()); //HomeShot için kullancıdan veri alıyoruz.

                if (HomeShot < 0)
                {
                    Console.WriteLine("Sayi negatif olamaz!");
                    goto startHomeShot; //Eğer negatif bir deger girerse başa dönmesi için goto kullandık.
                }

            startAwayShot:
                Console.Write("Rakip takimin attigi sut sayisi: ");
                AwayShot = float.Parse(Console.ReadLine()); //AwayShot için kullancıdan veri alıyoruz.

                if (AwayShot < 0)
                {
                    Console.WriteLine("Sayi negatif olamaz!");
                    goto startAwayShot; //Eğer negatif bir deger girerse başa dönmesi için goto kullandık.
                }

            startAwayCorner:
                Console.Write("Rakip takimin attigi korner sayisi: ");
                AwayCorner = float.Parse(Console.ReadLine()); //AwayCorner için kullancıdan veri alıyoruz.

                if (AwayCorner < 0)
                {
                    Console.WriteLine("Sayi negatif olamaz!");
                    goto startAwayCorner; //Eğer negatif bir deger girerse başa dönmesi için goto kullandık.
                }

                MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
                {
                    HomeTeam = HomeTeam,
                    AwayTeam = AwayTeam,
                    FTHomeGol = FTHomeGol,
                    FTAwayGol = FTAwayGol,
                    HomeShot = HomeShot,
                    AwayShot = AwayShot,
                    AwayCorner = AwayCorner,
                };

                // Make a single prediction on the sample data and print results
                var predictionResult = MLModel1.Predict(sampleData);

                Console.WriteLine($"HomeTeam: {HomeTeam}");
                Console.WriteLine($"AwayTeam: {AwayTeam}");
                Console.WriteLine($"FTHomeGol: {FTHomeGol}");
                Console.WriteLine($"FTAwayGol: {FTAwayGol}");
                Console.WriteLine($"HomeShot: {HomeShot}");
                Console.WriteLine($"AwayShot: {AwayShot}");
                Console.WriteLine($"AwayCorner: {AwayCorner}");


                Console.WriteLine($"\n\nTahmin edilen ev sahibi takimin attigi korner sayisi: {predictionResult.Score}\n\n");
                Console.Write("Cikmak icin cikis, devam etmek icin herhangi bir sey yaziniz. ");
                quit = Console.ReadLine();
                if (quit == "cikis") break; //Eger kullanıcı işlemin sonunda "cikis" yazarsa program sonlanacak.

            }
                Console.ReadKey();
            
        }
    }
}
