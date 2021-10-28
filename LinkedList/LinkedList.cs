using System;

namespace MyLinkedList
{

    public class LinkedList
    {
        public Node Head = null;

        // node a, b;
        public class Node
        {
            //CountryCode;
            public string CountryCode
            {
                get; set;
            }
            //CurrencyExchangeValue
            public double CurrencyExchangeValue
            {
                get; set;
            }
            //Next Node
            public Node Next;
            /// <summary>
            /// Set Country Code and Currency Exchange Value
            /// </summary>
            /// <param name="countryCode"></param>
            /// <param name="currencyExchangeValue"></param>
            public Node(string countryCode, double currencyExchangeValue)
            {
                CountryCode = countryCode;
                CurrencyExchangeValue = currencyExchangeValue;
            }
        }

        #region Public Methods
        /// <summary>
        /// Merge Sort
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public Node MergeSort(Node head)
        {
            // Base case : if head is null
            if (head == null || head.Next == null)
            {
                return head;
            }

            // get the middle of the list
            Node middleNode = GetMiddleNode(head);
            Node nextOfMiddleNode = middleNode.Next;

            // set the next of middle node to null
            middleNode.Next = null;

            // Apply mergeSort on left list
            Node leftNode = MergeSort(head);

            // Apply mergeSort on right list
            Node rightNode = MergeSort(nextOfMiddleNode);

            // Merge the left and right lists
            Node sortedlist = MergeSortedNodes(leftNode, rightNode);
            return sortedlist;
        }

        /// <summary>
        /// Push data into the LinkedList
        /// Insert new node at top
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="currencyExchangeValue"></param>
        public void Push(string countryCode, double currencyExchangeValue)
        {
            // For Testing: if the exchange rates are the same then sort using the currency code.
             // if (countryCode.Equals("aud") || countryCode.Equals("aed") || countryCode.Equals("inr") || countryCode.Equals("mga") || countryCode.Equals("cop"))
             //   currencyExchangeValue = 4542.3456;
            /* allocate node */
            Node newNode = new Node(countryCode, currencyExchangeValue);

            /* link the old list off the new node */
            newNode.Next = Head;

            ///* move the head to point to the new node */
            Head = newNode;
        }

        /// <summary>
        /// Utility function to print the linked list
        /// </summary>
        /// <param name="headref"></param>
        public void PrintList(Node headref)
        {
            int i = 0;
            while (headref != null)
            {
                Console.WriteLine(++i + " Country code: " + headref.CountryCode + "\t" + "Currency Exchange Value: " + headref.CurrencyExchangeValue);
                headref = headref.Next;
            }
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Return Middle Node
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private Node GetMiddleNode(Node head)
        {
            // Base case
            if (head == null)
                return head;
            Node fastNode = head.Next;
            Node slowNode = head;

            // Move fastNode by two and slow ptr by one
            // Finally slowNode will point to middle node
            while (fastNode != null)
            {
                fastNode = fastNode.Next;
                if (fastNode != null)
                {
                    slowNode = slowNode.Next;
                    fastNode = fastNode.Next;
                }
            }
            return slowNode;
        }
        /// <summary>
        /// Merging the sorted nodes
        /// </summary>
        /// <param name="leftNode"></param>
        /// <param name="rightNode"></param>
        /// <returns></returns>
        private Node MergeSortedNodes(Node leftNode, Node rightNode)
        {
            Node result;
            /* Base cases */
            if (leftNode == null)
                return rightNode;
            if (rightNode == null)
                return leftNode;

            /* Pick either leftNode or rightNode, and recur */
            //Sort by CurrencyExchangeValue desc
            if (leftNode.CurrencyExchangeValue > rightNode.CurrencyExchangeValue)
            {
                result = leftNode;
                result.Next = MergeSortedNodes(leftNode.Next, rightNode);
            }
            //If CurrencyExchangeValue are same for left and right node. Sort using Country Code
            else if (leftNode.CurrencyExchangeValue == rightNode.CurrencyExchangeValue
                && String.Compare(rightNode.CountryCode, leftNode.CountryCode) == 1)
            {
                result = leftNode;
                result.Next = MergeSortedNodes(leftNode.Next, rightNode);
            }
            else
            {
                result = rightNode;
                result.Next = MergeSortedNodes(leftNode, rightNode.Next);
            }
            return result;
        }
        #endregion

    }
}
