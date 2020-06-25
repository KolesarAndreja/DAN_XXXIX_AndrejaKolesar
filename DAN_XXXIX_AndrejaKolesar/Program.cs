using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XXXIX_AndrejaKolesar
{
    class Program
    {
        static void Main(string[] args)
        {

            Song song = new Song();
            Player player = new Player();
            
            string selected;
            do
            {
                Console.WriteLine("Select one option: \n1.Add new song \n2.Show all songs \n3.Exit");
                Console.Write("Your choice is: ");
                selected = Console.ReadLine();
                switch (selected)
                {
                    case "1":
                        song.AddSong();
                        break;
                    case "2":
                        player.PlaySong(); 
                        break;
                    case "3":
                        break;
                    default:
                        Console.Write("Invalid input.Try again: ");
                        break;
                }

            } while (selected != "3");
        }
    }
}
