using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StringSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] lines = File.ReadAllLines("../../../shakespeare-sonnets.txt");
            TextBox searchBox = (TextBox)FindName("SearchBox");
			string SearchPhrase = searchBox.Text;

			if (SearchPhrase != null && SearchPhrase != "")
			{

				// BruteSearch
				Stopwatch sw = new Stopwatch();
				sw.Start();
				int bruteSearch = BruteSearch(lines, SearchPhrase);
				sw.Stop();
				Label lbl = (Label)FindName("BruteLbl");
				lbl.Content = "Count: " + bruteSearch + ", Time (sec): " + sw.Elapsed.TotalSeconds;


				// KMP
				string text = File.ReadAllText("../../../shakespeare-sonnets.txt");
				Stopwatch sw2 = new Stopwatch();
				sw2.Start();
				int[] kmpResults = KMP(text, SearchPhrase);
				sw2.Stop();
				Label kmpLbl = (Label)FindName("KMPLbl");
				kmpLbl.Content = "Count: " + kmpResults.Length + ", Time (sec): " + sw2.Elapsed.TotalSeconds;


				// Boyer-Moore
				Stopwatch sw3 = new Stopwatch();
				sw3.Start();
				int bmResult = BoyerMoore(  SearchPhrase, text);
				sw3.Stop();
				Label bmLbl = (Label)FindName("BMLbl");
				bmLbl.Content = "Count: " + bmResult + ", Time (sec): " + sw3.Elapsed.TotalSeconds;

				// Rabin Karp
				Stopwatch sw4 = new Stopwatch();
				sw4.Start();
				int rkResult = RabinKarp(lines, SearchPhrase);
				sw4.Stop();
				Label rkLbl = (Label)FindName("RKLbl");
				rkLbl.Content = "Count: " + rkResult + ", Time (sec): " + sw4.Elapsed.TotalSeconds;

			}
		}

		//========================================================================================================================================================
		//BRUTE SEARCH
		private int BruteSearch(string[] lines, string searchPhrase)
        {
            int count = 0;
            for(int i = 0; i < lines.Length; i++)
            {
                string l = lines[i];
				int r = l.IndexOf(searchPhrase);
				while (r > -1)
				{
					count++;
					l = l.Substring(r + searchPhrase.Length);
					r = l.IndexOf(searchPhrase);
				}
            }

            return count;
        }

		//========================================================================================================================================================
		//KMP
		public static int[] KMP(string line, string searchPhrase)
		{
			List<int> retVal = new List<int>();
			int M = searchPhrase.Length;
			int N = line.Length;
			int i = 0;
			int j = 0;
			int[] lps = new int[M];

			ComputeLPS(searchPhrase, M, lps);

			while (i < N)
			{
				if (searchPhrase[j] == line[i])
				{
					j++;
					i++;
				}

				if (j == M)
				{
					retVal.Add(i - j);
					j = lps[j - 1];
				}

				else if (i < N && searchPhrase[j] != line[i])
				{
					if (j != 0)
						j = lps[j - 1];
					else
						i = i + 1;
				}
			}

			return retVal.ToArray();
		}

		private static void ComputeLPS(string searchPhrase, int m, int[] lps)
		{
			int len = 0;
			int i = 1;

			lps[0] = 0;

			while (i < m)
			{
				if (searchPhrase[i] == searchPhrase[len])
				{
					len++;
					lps[i] = len;
					i++;
				}
				else
				{
					if (len != 0)
					{
						len = lps[len - 1];
					}
					else
					{
						lps[i] = 0;
						i++;
					}
				}
			}
		}
		//========================================================================================================================================================
		//KMP END



		//========================================================================================================================================================
		//BOYER-MOORE
	
		

		private static int[] BuildBadCharTable2(char[] needle)
		{
			int[] badShift = new int[256];
			for (int i = 0; i < 256; i++)
			{
				badShift[i] = needle.Length;
			}
			int last = needle.Length - 1;
			for (int i = 0; i < last; i++)
			{
				badShift[(int)needle[i]] = last - i;
			}
			return badShift;
		}

		public static int BoyerMoore(String pattern, String text)
		{
			char[] needle = pattern.ToCharArray();
			char[] haystack = text.ToCharArray();

			if (needle.Length > haystack.Length)
			{
				return -1;
			}
			int[] badShift = BuildBadCharTable2(needle);
			int offset = 0;
			int scan = 0;
			int last = needle.Length - 1;
			int maxoffset = haystack.Length - needle.Length;
			while (offset <= maxoffset)
			{
				for (scan = last; (needle[scan] == haystack[scan + offset]); scan--)
				{
					if (scan == 0)
					{ //Match found
						return offset;
					}
				}
				offset += badShift[(int)haystack[offset + last]];
			}
			return -1;
		}

		//========================================================================================================================================================
		//BOYER-MOORE END

		//========================================================================================================================================================
		//RABIN-KARP 

		public static int RabinKarp(string[] lines, string searchPhrase)
		{
			int count = 0;
			for (int z = 0; z < lines.Length; z++)
			{
				string line = lines[z];
				if (line.Length == 0 || line.Length < searchPhrase.Length)
                {
					continue;
                }
				List<int> retVal = new();
				ulong siga = 0;
				ulong sigb = 0;
				ulong Q = 100007;
				ulong D = 256;

				for (int i = 0; i < searchPhrase.Length; ++i)
				{
					siga = (siga * D + (ulong)line[i]) % Q;
					sigb = (sigb * D + (ulong)searchPhrase[i]) % Q;
				}

				if (siga == sigb)
					retVal.Add(0);

				ulong pow = 1;

				for (int k = 1; k <= searchPhrase.Length - 1; ++k)
					pow = (pow * D) % Q;

				for (int j = 1; j <= line.Length - searchPhrase.Length; ++j)
				{
					siga = (siga + Q - pow * (ulong)line[j - 1] % Q) % Q;
					siga = (siga * D + (ulong)line[j + searchPhrase.Length - 1]) % Q;

					if (siga == sigb)
						if (line.Substring(j, searchPhrase.Length) == searchPhrase)
							retVal.Add(j);
				}

				count += retVal.ToArray().Length;
			}
			return count;
				}


		//========================================================================================================================================================
		//RABIN-KARP END

	}
}
