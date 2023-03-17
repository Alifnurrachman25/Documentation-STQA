using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Documentation_STQA
{
    /// <summary>
    /// Jadi di project kali ini memiliki 3 Class yaitu, class Node, Class DoubleLinkedList, Class Program
    /// </summary>
    /// <remarks> class Node dapat membuat class double link list bekerja, class ini dapat mendeklarasi dari masing masing atribut dengan
    /// tipe data integer, string, dan Node.</remarks>
    class Node
    {
        /// <summary>
        /// Di dalam class Node ini hanya untuk mendeklarasikan atribut saja
        /// </summary>
        public int nim;
        public string nama;
        public string kelas;
        public string jeniskelamin;
        public string asalKota;
        public Node next;
        public Node prev;
    }
    /// <summary>
    /// Class double linked list lah yang menjalankan program ini
    /// </summary>
    /// <remarks> Class double linked list dapat melakukan menambahkan node, menghapus node, mencari, mengurutkan.</remarks>
    class DoubleLinkedList
    {
        //di awali dengan START Node
        Node START;

        public DoubleLinkedList()
        {
            //Node di deklarasikan kosong
            START = null;
        }
        public void addNode()
        {
            int nis;
            string nm;
            string kls;
            string jk;
            string akt;
            Console.Write("\nMasukkan NIM mahasiswa: ");
            //Kita bisa memasukkan NIM mahasiswa
            nis = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan Nama mahasiswa: ");
            //Kita bisa memasukkan nama mahasiswa
            nm = Console.ReadLine();
            Console.Write("\nMasukkan Kelas mahasiswa: ");
            //Kita bisa memasukkan kelas mahasiswa
            kls = Console.ReadLine();
            Console.Write("\nMasukkan Jenis kelamin mahasiswa: ");
            //Kita bisa memasukkan jenis kelamin mahasiswa
            jk = Console.ReadLine();
            Console.Write("\nMasukkan Asal kota mahasiswa: ");
            //Kita bisa memasukkan asal kota mahasiswa
            akt = Console.ReadLine();
            Node newNode = new Node();
            newNode.nim = nis;
            newNode.nama = nm;
            newNode.kelas = kls;
            newNode.jeniskelamin = jk;
            newNode.asalKota = akt;

            if (START == null || nis <= START.nim)
            {
                if ((START != null) && (nis == START.nim))
                // ini adalah algoritma jika nim kembar
                {
                    Console.WriteLine("\nDuplikat NIM tidak di izinkan!");
                    //Jika nim kembar maka akan muncul teks duplikat nim tidak di izinkan
                    return;
                }
                newNode.next = START;
                //jika START tidak kosong, maka akan muncul node baru
                if (START != null)
                    START.prev = newNode;
                newNode.prev = null;
                START = newNode;
                return;
            }
            Node previous, current;
            for (current = previous = START;
                current != null && nis >= current.nim;
                previous = current, current = current.next)
            {
                if (nis == current.nim)
                // ini adalah algoritma jika nim kembar
                {
                    Console.WriteLine("\nDuplikat NIM tidak di izinkan!");
                    //Jika nim kembar maka akan muncul teks duplikat nim tidak di izinkan
                    return;
                }
            }
            //mendeklarasikan node yang ada di current
            newNode.next = current;
            //mendeklarasikan node agar bisa mundur
            newNode.prev = previous;

            //algoritma jika current kosong
            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        // ini adalah method search agar kita bisa search sesuai nama kota
        public bool search(string kota, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;


            while ((current != null) && (kota != current.asalKota))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return (true);

        }
        // ini adalah method delete node agar kita bisa delete sesuai kota yang kita mau
        public bool DellNode(string kota)
        {
            Node previous, current;
            previous = current = null;
            if (search(kota, ref previous, ref current) == false)
                return false;
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            previous.next = current.next;
            current.next.prev = previous;
            return true;

        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        // ini adalah method mengurutkan dari kecil ke besar
        public void ascending()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong");
            else
            {
                Console.WriteLine("\nUrutan naik dari list " + "NIM adalah:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.nama + " " + currentNode.nim + " " + currentNode.kelas + " " + currentNode.jeniskelamin + " " + currentNode.asalKota + "\n");
            }
        }

        // ini adalah method mengurutkan dari yang besar ke kecil
        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong");
            else
            {
                Console.WriteLine("\nUrutan menurun dari " + "NIM adalah:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next) { }

                while (currentNode != null)
                {
                    Console.Write(currentNode.nama + " " + currentNode.nim + " " + currentNode.kelas + " " + currentNode.jeniskelamin + " " + currentNode.asalKota + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }

    }

    /// <summary>
    /// Yang terakhir adalah class program dimana program ini akan berjalan dengan ada nya class ini, class program terdiri dari menu option
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    //ini adalah beberapa menu option
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Tambah mahasiswa ke list");
                    Console.WriteLine("2. Hapus mahasiswa ke list");
                    Console.WriteLine("3. Tampilkan semua mahasiswa dari list dengan urutan naik NIM ");
                    Console.WriteLine("4. Tampilkan semua mahasiswa dari list dengan urutan turun NIM ");
                    Console.WriteLine("5. Cari mahasiswa di list");
                    Console.WriteLine("6. Exit\n");
                    Console.Write("Masukkan pilihan anda (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        // case 1 adalah case yang akan mengarahkan kita ke algoritma tambah node
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;

                        //case 2 adalah case yang akan mengarahkan kita ke algoritma menghapus node
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList kosong");
                                    break;
                                }
                                Console.Write("\nMasukkan NIM mahasiswa" +
                                    "yang akan dihapus:");
                                string nim = Convert.ToString(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.DellNode(nim) == false)
                                    Console.Write("Mahasiswa tidak di temukan");
                                else
                                    Console.WriteLine("Mahasiswa yang mempunyai NIM " + nim + " telah dihapus \n");
                            }
                            break;

                        //case 3 adalah case yang akan mengarahkan kita ke algoritma mengurutkan dari kecil ke besar
                        case '3':
                            {
                                obj.ascending();
                            }
                            break;

                        // case 4 adalah case yang akan mengarahkan kita ke algoritma yang mengurutkan dari besar ke kecil
                        case '4':
                            {
                                obj.descending();
                            }
                            break;
                        /* case 5 adalah case yang akan mengarahkan kita ke algoritma search yang dimana kita bisa melakukan pencarian
                           sesuai sama kota yang kita mau */
                        case '5':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList kosong");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\n Masukkan asal kota mahasiswa yang akan dicari: ");
                                string kota = Convert.ToString(Console.ReadLine());
                                if (obj.search(kota, ref prev, ref curr) == false)
                                    Console.WriteLine("\nMahasiswa tidak ditemukan");
                                else
                                {
                                    Console.WriteLine("\nMahasiswa ditemukan!");
                                    Console.WriteLine("\nnama: " + curr.nama);
                                    Console.WriteLine("\nNIM: " + curr.nim);
                                    Console.WriteLine("\nnama: " + curr.kelas);
                                    Console.WriteLine("\nnama: " + curr.jeniskelamin);
                                    Console.WriteLine("\nnama: " + curr.asalKota);
                                }
                            }
                            break;

                        // case 6 adalah case dimana jika kita salah memilih di menu maka akan muncul pilihan tidak tersedia
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan tidak tersedia");
                            }
                            break;
                    }
                }
                //jika salah memasukkan pilihan maka akan muncul teks silahkan cek kembali yang anda masukkan
                catch (Exception)
                {
                    Console.WriteLine("Silahkan cek kembali yang anda masukkan.");
                }
            }
        }
    }
}
