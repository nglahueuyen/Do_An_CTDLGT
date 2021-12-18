using System;

namespace DoAn
{
    class Program
    {
        public static void Intro()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0,92}", " _    _  _____  _    _");
            Console.WriteLine("{0,93}", "| |  | ||  ___|| |  | |");
            Console.WriteLine("{0,93}", "| |  | || |__  | |__| |");
            Console.WriteLine("{0,93}", "| |  | ||  __| |  __  |");
            Console.WriteLine("{0,93}", "| |__| || |___ | |  | |");
            Console.WriteLine("{0,93}", "|______||_____||_|  |_|");
            Console.WriteLine("\n");
            Console.WriteLine("{0,100}", "ĐỒ ÁN: CẤU TRÚC DỮ LIỆU VÀ GIẢI THUẬT", Console.ForegroundColor = ConsoleColor.Yellow);
            Console.Write("{0,94}", "CHỦ ĐỀ: ĐỒ THỊ ĐỊA ĐIỂM\n", Console.ForegroundColor = ConsoleColor.Red);
            for (int i = 0; i < 6; i++)
            {
                for (int j = 1; j < 6 - i; j++)
                {
                    Console.Write(" ");
                }
                Console.Write("{0,77}", " ");
                for (int k = 1; k <= i; k++)
                {

                    Console.Write("* ", Console.ForegroundColor = ConsoleColor.Green);
                }
                Console.Write("{0,90}", "\n");
            }
            for (int i = 1; i <= 1; i++)
            {
                for (int j = 1; j < 0; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= 1; k++)
                {
                    Console.Write("{0,84}", " * * ");
                }
                Console.Write("\n");
            }
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0,79}{1,20}", "GIÁO VIÊN HƯỚNG DẪN :", " ĐẶNG NGỌC HOÀNG THÀNH");
            Console.WriteLine("{0,79}{1,20}", "DANH SÁCH NHÓM :", " TRẦN HOÀNG THANH THY");
            Console.WriteLine("{0,98}", "NGUYỄN THỊ THẢO LY");
            Console.WriteLine("{0,97}", "LÂM THỊ YẾN DƯƠNG");
            Console.WriteLine("{0,98}", "NGUYỄN LA HUỆ UYÊN");
            Console.WriteLine("{0,101}", "PHẠM LÊ PHƯƠNG TRINH\n");
            Console.WriteLine("{0,101}", "*************************************\n", Console.ForegroundColor = ConsoleColor.Cyan);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Main(string[] args)
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Graph theGraph = new Graph();
            //--------------------------------------------------------------------------------------------------------------------------------

            theGraph.AddVertex(new Location("1", 10.782967f, 106.6926484f, "Đại Học UEH Cơ Sở A", "Hồ Chí Minh", "3")); //0
            theGraph.AddVertex(new Location("2", 10.760905f, 106.6657665f, "Đại Học UEH Cơ Sở B", "Hồ Chí Minh", "10")); //1
            theGraph.AddVertex(new Location("3", 10.773177f, 106.6753573f, "Đại Học UEH Cơ Sở C", "Hồ Chí Minh", "10")); //2
            theGraph.AddVertex(new Location("4", 10.791699f, 106.6862103f, "Đại Học UEH Cơ Sở D", "Hồ Chí Minh", "1")); //3
            theGraph.AddVertex(new Location("5", 10.790476f, 106.6971515f, "Đại Học UEH Cơ Sở E", "Hồ Chí Minh", "1")); //4
            theGraph.AddVertex(new Location("6", 10.760462f, 106.6700192f, "Đại Học UEH Cơ Sở H", "Hồ Chí Minh", "Phú Nhuận")); //5
            theGraph.AddVertex(new Location("7", 10.782586f, 106.6932257f, "Đại Học UEH Cơ Sở I", "Hồ Chí Minh", "3")); //6
            theGraph.AddVertex(new Location("8", 10.781823f, 106.6851013f, "Đại Học UEH Cơ Sở V", "Hồ Chí Minh", "3")); //7
            theGraph.AddVertex(new Location("9", 10.722329f, 106.6194257f, "Đại Học UEH Cơ Sở GDTC", "Hồ Chí Minh", "8")); //8
            theGraph.AddVertex(new Location("10", 10.705942f, 106.6379664f, "Đại Học UEH Cơ Sở N", "Hồ Chí Minh", "Bình Chánh")); //9

            //---------------------------------------------------------------------------------------------------------------------------------

            theGraph.AddEdge(0, 1, 4); theGraph.AddEdge(0, 3, 2);
            theGraph.AddEdge(1, 2, 2); theGraph.AddEdge(1, 6, 5); theGraph.AddEdge(1, 4, 5);
            theGraph.AddEdge(2, 6, 3); theGraph.AddEdge(2, 5, 5);
            theGraph.AddEdge(3, 4, 2); theGraph.AddEdge(3, 7, 2);
            theGraph.AddEdge(4, 6, 1); theGraph.AddEdge(4, 9, 15);
            theGraph.AddEdge(5, 8, 15); theGraph.AddEdge(5, 9, 17);
            theGraph.AddEdge(6, 8, 12); theGraph.AddEdge(6, 5, 3);
            theGraph.AddEdge(7, 9, 15);
            theGraph.AddEdge(8, 9, 16);

            //----------------------------------------------------------------------------------------------------

            bool decide = true;
            while (decide)
            {
                Intro();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t\t>> Danh sách địa điểm:\n");
                theGraph.ShowVerts();
                Console.WriteLine("\n" + "{0,101}", "_____________________________________\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Option 1: Tìm đường đi ngắn nhất");
                Console.WriteLine("Option 2: Tính thời gian di chuyển");
                Console.WriteLine("Option 3: Tìm kiếm địa điểm theo thuật toán Depth First Search");
                Console.WriteLine("Option 4: Tìm kiếm địa điểm theo thuật toán Breadth First Search");
                Console.WriteLine("Option 5: Kết thúc chương trình");
                Console.Write("\nNhập vào option: ");
                byte option = byte.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("\nHÃY CÙNG BẮT  ĐẦU GHÉ THĂM CÁC CƠ SỞ CỦA ĐẠI HỌC UEH :)\nVí dụ: Để chọn Cơ Sở A -> Nhập 'A'\n       Cơ Sở Giáo Dục Thể Chất -> Nhập 'G'", Console.ForegroundColor = ConsoleColor.DarkCyan);
                        Console.Write("\nBạn muốn xuất phát từ cơ sở nào ?: \t", Console.ForegroundColor = ConsoleColor.White);
                        char FromCs = char.Parse(Console.ReadLine());
                        Console.Write("Và điểm đến đầu tiên sẽ là:\t");
                        char ToCs = char.Parse(Console.ReadLine());
                        theGraph.Path(FromCs, ToCs, 1);
                        Console.Write("\n\tBạn muốn đi tiếp chứ ? ", Console.ForegroundColor = ConsoleColor.Yellow);
                        Console.Write("\tnhấn 1 để tiếp tục", Console.ForegroundColor = ConsoleColor.Green);
                        Console.WriteLine("\tnhấn 0 kết thúc chuyến đi", Console.ForegroundColor = ConsoleColor.Red);
                        Console.ForegroundColor = ConsoleColor.White;
                        byte d = byte.Parse(Console.ReadLine());
                        while (d == 1)
                        {
                            FromCs = ToCs;
                            Console.Write("Điểm đến kế tiếp sẽ là:\t");
                            ToCs = char.Parse(Console.ReadLine());
                            theGraph.Path(FromCs, ToCs, 1);
                            Console.Write("\tBạn muốn đi tiếp chứ ? ", Console.ForegroundColor = ConsoleColor.Yellow);
                            Console.Write("\tnhấn 1 để tiếp tục", Console.ForegroundColor = ConsoleColor.Green);
                            Console.WriteLine("\tnhấn 0 kết thúc chuyến đi", Console.ForegroundColor = ConsoleColor.Red);
                            Console.ForegroundColor = ConsoleColor.White;
                            d = byte.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("\tMONG BẠN ĐÃ CÓ TRẢI NGHIỆM THÚ VỊ :) !", Console.ForegroundColor = ConsoleColor.Cyan);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("\nTÍNH THỜI GIAN DI CHUYỂN\n", Console.ForegroundColor = ConsoleColor.DarkCyan);
                        Console.WriteLine("Nhấn phím '1': Xe máy\nNhấn phím '2': Xe bus\nNhấn phím '3': Xe đạp");
                        int op = int.Parse(Console.ReadLine());
                        Console.Write("\nBạn muốn xuất phát từ cơ sở nào ?: \t", Console.ForegroundColor = ConsoleColor.White);
                        FromCs = char.Parse(Console.ReadLine());
                        Console.Write("Và điểm đến đầu tiên sẽ là:\t");
                        ToCs = char.Parse(Console.ReadLine());
                        theGraph.Time(FromCs, ToCs, op);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("\nTÌM KIẾM ĐỊA ĐIỂM THEO THUẬT TOÁN DEPTH FIRST SEARCH\n", Console.ForegroundColor = ConsoleColor.DarkCyan);
                        Console.ForegroundColor = ConsoleColor.White;
                        theGraph.DepthFirstSearch();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("\nTÌM KIẾM ĐỊA ĐIỂM THEO THUẬT TOÁN BREADTH FIRST SEARCH\n", Console.ForegroundColor = ConsoleColor.DarkCyan);
                        Console.ForegroundColor = ConsoleColor.White;
                        theGraph.BreadthFirstSearch();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5: decide = false; break;
                    default:
                        Console.WriteLine("Nhập sai yêu cầu! Vui lòng nhập lại", Console.ForegroundColor = ConsoleColor.DarkRed);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("CHEERS!");
        }
    }
}