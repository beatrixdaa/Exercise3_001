using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exerchise3_001
{
    class Node
    {
        /*create Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        /*searches for the specified node*/
        {
            for (previous = current = LAST.next;
                current != LAST;
                previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true);   /* returns true if the node is found*/

            }
            if (rollNo == LAST.rollNumber) /*if the node is present at the end*/
                return true;
            else
                return (false); /*retuns false if the node is not found*/


        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse() /*Traverses all the nodes of the list*/
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are : \n");
                Node currentNode;
                curentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + " " +
                    currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + "   " + LAST.name + "  ");
            }
            
             void firstNode()
            {
                if (listEmpty())
                    Console.WriteLine("\nList is empty");
                else
                    Console.WriteLine("\nThe first record in the list is : \n\n " +
                        LAST.next.rollNumber + "  " + LAST.next.name);
            }
             //Menambahkan method insert
              void insert()
            {
                int rollNumber;
                string rollno;
                Console.WriteLine("\nMasukkan nomor : ");
                rollNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nMasukkan nama: ");
                rollNumber = Console.Read();

                Node nodebaru = new Node();
                nodebaru.rollNumber = rollNumber;
                nodebaru.name = rollno;
                //Node ditambahkan sebagai node pertama
                if (LAST == null || rollNumber != LAST.rollNumber)
                {
                    if ((LAST != null || rollNumber == LAST.rollNumber))
                    {
                        Console.WriteLine("\n ");
                    }
                    nodebaru.next = LAST;
                    LAST = nodebaru;
                    return;
                }
            }
            //Method untuk menghapus variabel tertentu didalam list
            bool delete(int rollNo)
            {
                Node previous, current;
                previous = current = null;
                if (Search(rollNo, ref previous, ref current) == false)
                    return false;
                previous.next = current.next;
                if (current == LAST)

                    LAST = LAST.next;
                return true;

            }
        }
    }
    class Program
        {
            static void Main(string[] args)
            {
                CircularList obj = new CircularList();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nMenu");
                        Console.WriteLine("1. View all the record in the list");
                        Console.WriteLine("2. Search for a record in the list");
                        Console.WriteLine("3. Display the first record in the list");
                        Console.WriteLine("4. Exit");
                        Console.WriteLine("\nEnter your choice (1-4):");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.traverse();
                                }
                                break;
                            case '2':
                                {
                                    if (obj.listEmpty() == true)
                                    {
                                        Console.WriteLine("\nList is empty");
                                        break;
                                    }
                                    Node prev, curr;
                                    prev = curr = null;
                                    Console.Write("\nEnter the roll number of the student whose record is to be searched :");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(num, ref prev, ref curr) == false)
                                        Console.WriteLine("\nRecord found");
                                    else
                                    {
                                        Console.WriteLine("\nRecord found");
                                        Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                        Console.WriteLine("\nName: " + curr.name);

                                    }
                                }
                                break;
                            case '3':
                                {
                                    obj.firstNode();
                                }
                                break; ;
                            case '4':
                                return;
                            default:
                                {
                                    Console.WriteLine("Invalid option");
                                    break;
                                }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
        }
    }