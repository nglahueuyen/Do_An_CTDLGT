using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    public class Distoriginal
    {
        public int distance; public int parentVert;
        public Distoriginal(int pv, int d)
        {
            distance = d; parentVert = pv;
        }
    }
    public class Vertex
    {
        public Location label;
        public bool isInTree;
        public Vertex(Location lab) { label = lab; isInTree = false; }
    }
    public class Graph
    {
        private const int max_verts = 10;
        int infinity = 100;
        Vertex[] vertexList; int[,] adjMat; int[,] adjMat2;
        int nVerts; int nTree; Distoriginal[] spath;
        int currentVert; int startToCurrent;
        public Graph()
        {
            vertexList = new Vertex[max_verts];
            adjMat = new int[max_verts, max_verts];
            adjMat2 = new int[max_verts, max_verts];
            nVerts = 0; nTree = 0;
            for (int j = 0; j < max_verts; j++)
                for (int k = 0; k < max_verts; k++)
                    adjMat[j, k] = infinity;
            spath = new Distoriginal[max_verts];
        }
        public void AddVertex(Location lab)
        {
            vertexList[nVerts] = new Vertex(lab);
            nVerts++;
        }
        public void AddEdge(int start, int theEnd, int weight)
        {
            adjMat[start, theEnd] = weight;
            adjMat[theEnd, start] = weight;
            adjMat2[start, theEnd] = 1;
            adjMat2[theEnd, start] = 1;
        }
        public void Path(char FromCs, char ToCs, byte d)
        {
            int Fromcs = FindCS(FromCs);
            int Tocs = FindCS(ToCs);
            int startTree = Fromcs;
            vertexList[startTree].isInTree = true;
            nTree = 1;
            for (int j = 0; j < nVerts; j++)
            {
                int tempDist = adjMat[startTree, j];
                spath[j] = new Distoriginal(startTree, tempDist);
            }
            while (nTree < nVerts)
            {
                int indexMin = GetMin();
                int minDist = spath[indexMin].distance;
                currentVert = indexMin;
                startToCurrent = spath[indexMin].distance;
                vertexList[currentVert].isInTree = true;
                nTree++;
                AdjustShortPath();
            }
            DisplayPaths(Fromcs, Tocs);
            if (d == 1) Stop(Fromcs, Tocs);
            nTree = 0;
            for (int j = 0; j < nVerts; j++)
                vertexList[j].isInTree = false;
        }
        public int GetMin()//Tìm điểm có giá trị nhỏ nhất trong hàng
        {
            int minDist = infinity;
            int indexMin = 0;
            for (int j = 0; j <= nVerts - 1; j++)
                if (!(vertexList[j].isInTree) && spath[j].distance < minDist)
                {
                    minDist = spath[j].distance; indexMin = j;
                }
            return indexMin;
        }
        public void AdjustShortPath()//So sánh giá trị mới với giá trị đã tồn tại, chọn gái trị nhỏ hơn
        {
            int column = 0;
            while (column < nVerts)
                if (vertexList[column].isInTree) column++;
                else
                {
                    int currentToFring = adjMat[currentVert, column];
                    int startToFringe = startToCurrent + currentToFring;
                    int sPathDist = spath[column].distance;
                    if (startToFringe < sPathDist)
                    {
                        spath[column].parentVert = currentVert;
                        spath[column].distance = startToFringe;
                    }
                    column++;
                }
        }
        public void DisplayPaths(int FromCs, int ToCs)
        {
            Location parent = vertexList[spath[FromCs].parentVert].label;
            Console.Write("Từ " + parent.GetName() + " đến " + vertexList[ToCs].label.GetName() + " = ");
            if (spath[ToCs].distance != infinity)
                Console.WriteLine(spath[ToCs].distance + " km");
            else Console.WriteLine(" 0 km");
        }

        public int FindCS(char cs)
        {
            switch (cs)
            {
                case 'A': return 0;
                case 'B': return 1;
                case 'C': return 2;
                case 'D': return 3;
                case 'E': return 4;
                case 'H': return 5;
                case 'I': return 6;
                case 'V': return 7;
                case 'G': return 8;
                case 'N': return 9;
                default: return -1;
            }
        }

        public void Stop(int h, int k)
        {
            Stack tram = new Stack();
            tram.Push(k);
            do
            {
                tram.Push(spath[k].parentVert);
                k = spath[k].parentVert;
            }
            while (k != h);
            Console.WriteLine("Từ " + vertexList[(int)tram.Peek()].label.GetName() + ", quận " + vertexList[(int)tram.Pop()].label.GetDistrict() + " đi qua " + (tram.Count - 1) + " trạm: ");
            while (tram.Count != 1)
            {
                Console.WriteLine("\t" + vertexList[(int)tram.Peek()].label.GetName() + ", quận " + vertexList[(int)tram.Pop()].label.GetDistrict() + ";");
            }
            Console.WriteLine("để tới trạm cuối " + vertexList[(int)tram.Peek()].label.GetName() + ", quận " + vertexList[(int)tram.Pop()].label.GetDistrict() + ";");
        }

        public void ShowVerts()
        {
            foreach (Vertex e in vertexList)
            {
                Console.WriteLine("\t\t\t" + (e.label).ToString());
            }
        }

        private int GetAdjUnvisitedVertex(int v)
        {
            for (int j = 0; j <= nVerts - 1; j++)
                if ((adjMat2[v, j] == 1) && (vertexList[j].isInTree == false))
                    return j;
            return -1;
        }
        public void BreadthFirstSearch()
        {
            Queue gQueue = new Queue();
            vertexList[0].isInTree = true;
            Console.WriteLine(vertexList[0].label.ToString() + " ");
            gQueue.Enqueue(0);
            int vert1, vert2;
            while (gQueue.Count > 0)
            {
                vert1 = (int)gQueue.Dequeue();
                vert2 = GetAdjUnvisitedVertex(vert1);
                while (vert2 != -1)
                {
                    vertexList[vert2].isInTree = true;
                    Console.WriteLine(vertexList[vert2].label.ToString() + " ");
                    gQueue.Enqueue(vert2);
                    vert2 = GetAdjUnvisitedVertex(vert1);
                }
            }
            for (int i = 0; i <= nVerts - 1; i++)
                vertexList[i].isInTree = false;
        }
        public void DepthFirstSearch()
        {
            vertexList[0].isInTree = true;
            Console.WriteLine(vertexList[0].label.ToString() + " ");
            Stack gStack = new Stack();
            gStack.Push(0);
            int v;
            while (gStack.Count > 0)
            {
                v = GetAdjUnvisitedVertex((int)gStack.Peek());
                if (v == -1)
                    gStack.Pop();
                else
                {
                    vertexList[v].isInTree = true;
                    Console.WriteLine(vertexList[v].label.ToString() + " ");
                    gStack.Push(v);
                }
            }
            for (int j = 0; j <= nVerts - 1; j++)
                vertexList[j].isInTree = false;
        }
        public void Time(char Fromcs, char Tocs, int op)
        {
            int vbike = 32;
            int vbus = 40;
            int vbicycle = 20;
            Path(Fromcs, Tocs, 0);
            int ToCs = FindCS(Tocs);
            int FromCs = FindCS(Fromcs);
            if (spath[ToCs].distance != infinity)
                switch (op)
                {
                    case 1:
                        double tbike = Math.Round((double)spath[ToCs].distance / vbike, 1);
                        Console.WriteLine("\nThời gian đi bằng xe máy cho đoạn đường từ {0} đến {1} là: {2} giờ", vertexList[FromCs].label.GetName(), vertexList[ToCs].label.GetName(), tbike);
                        break;
                    case 2:
                        double tbus = Math.Round((double)spath[ToCs].distance / vbus, 1);
                        Console.WriteLine("\nThời gian đi bằng xe bus cho đoạn đường từ {0} đến {1} là: {2} giờ", vertexList[FromCs].label.GetName(), vertexList[ToCs].label.GetName(), tbus);
                        break;
                    case 3:
                        double tbicycle = Math.Round((double)spath[ToCs].distance / vbicycle, 1);
                        Console.WriteLine("\nThời gian đi bằng xe đạp cho đoạn đường từ {0} đến {1} là: {2} giờ", vertexList[FromCs].label.GetName(), vertexList[ToCs].label.GetName(), tbicycle);
                        break;
                    default:
                        Console.WriteLine("Nhập sai ! Hãy nhập lại");
                        break;
                }
            else Console.WriteLine("Bạn đang đứng tại nơi cần đến rồi đó.\nCheers!");
        }
    }
}