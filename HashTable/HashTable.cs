using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class HashTable
    {
        public class Node
        {
            public string key;
            public int data;
            public Node next;
            public Node(string key, int data, Node next)
            {
                this.key = key;
                this.data = data;
                this.next = next;
            }
        }
        private int s;
        private Node[] array;
        public HashTable(int size)
        //конструктор хэш-таблицы
        {
            this.s = size;
            this.array = new Node[s];
        }
        public HashTable()
        {
            this.s = 1000;
            this.array = new Node[s];
        }
        private int GetHash(string key)
        //вычисление хэша
        {
            char[] kchar = key.ToCharArray();
            int l = kchar.Length;
            int hash = 0;
            for (int i = 0; i < l; i++)
            {
                if (l == 1) hash = kchar[0];
                else hash += kchar[i];
            }
            return hash % s;
        }
        public void Add(int value, string key)
        //добавление
        {
            int h = GetHash(key);
            Node p = array[h];
            bool ok = false;
            while ((p != null) && (!ok))
                if (p.key == key)
                {
                    ok = true;
                    p.data = value;
                }
                else p = p.next;

            if (!ok)
            {
                if (array[h] == null) array[h] = new Node(key, value, null);
                else array[h] = new Node(key, value, array[h]);
            }
        }
        private bool Presence(string key)
        //проверка на наличие
        {
            int h = GetHash(key);
            Node p = array[h];
            bool f = false;
            while ((p != null) && (!f))
                if (p.key == key) f = true;
                else p = p.next;
            return f;
        }
        public int Search(int key)
        //поиск
        {
            int h = key;
            Node p = array[h];
            T res = default(T);
            if (Presence(p.key)) 
                res = p.data;
            else 
                Console.WriteLine("This element does not exist");
            return res;
        }
        public void Delete(int key)
        //удаление
        {
            int h = key;
            if (array[h] == null) Console.WriteLine("This element does not exist");
            if (array[h].data == key)
                array[h] = array[h].next;
            else
            {
                Node p = array[h];
                bool f = false;
                while ((p.next != null) && (!f))
                    if (p.next.data == key)
                        f = true;
                    else p = p.next;
                if (f)
                    p.next = p.next.next;
            }
        }
    }
}
