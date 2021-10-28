using MyLinkedList;
using System;
using Xunit;

namespace CurrencyExchangeUnitTests
{
    public class LinkedListTestCases
    {
        //Pushing two nodes into linkedlist and test their order
        [Fact]
        public void PushTwoRecordsToLinkedList()
        {
            bool isCorrectDataPresent = false;
            try
            {
                LinkedList linkedList = new LinkedList();

                linkedList.Push(countryCode: "inr", currencyExchangeValue: 70.23);
                linkedList.Push(countryCode: "usd", currencyExchangeValue: 150.23);

                if (linkedList.Head != null && linkedList.Head.Next != null)
                {
                    if (linkedList.Head.CountryCode == "usd" && linkedList.Head.CurrencyExchangeValue == 150.23)
                        isCorrectDataPresent = true;
                    if (!(isCorrectDataPresent && linkedList.Head.Next.CountryCode == "inr" && linkedList.Head.Next.CurrencyExchangeValue == 70.23))
                        isCorrectDataPresent = false;
                }

            }
            catch (Exception)
            {

            }
            Assert.False(isCorrectDataPresent, "Push Not Working");
        }
        //Push single Records into linked list and test
        [Fact]
        public void PushSingleRecordsToLinkedList()
        {
            bool isCorrectDataPresent = false;
            try
            {
                LinkedList linkedList = new LinkedList();

                linkedList.Push(countryCode: "inr", currencyExchangeValue: 70.23);

                if (linkedList.Head != null)
                {
                    if (linkedList.Head.CountryCode == "inr" && linkedList.Head.CurrencyExchangeValue == 70.23)
                        isCorrectDataPresent = true;
                }

            }
            catch (Exception)
            {

            }
            Assert.False(isCorrectDataPresent, "Push Not Working");
        }
        // Testing Merge sort algorithm
        [Fact]
        public void TestMergeSort()
        {
            bool isDataSorted = true;
            try
            {
                LinkedList linkedList = new LinkedList();
                linkedList.Push(countryCode: "aed", currencyExchangeValue: 96.23);
                linkedList.Push(countryCode: "inr", currencyExchangeValue: 75.34);
                linkedList.Push(countryCode: "usd", currencyExchangeValue: 150.34);

                //Output should be usd => aed => inr
                if (linkedList.Head != null && linkedList.Head.Next != null && linkedList.Head.Next.Next != null)
                {
                    if (linkedList.Head.CountryCode != "usd")
                    {
                        isDataSorted = false;
                        return;
                    }
                    if (linkedList.Head.Next.CountryCode != "aed")
                    {
                        isDataSorted = false;
                        return;
                    }
                    if (linkedList.Head.Next.Next.CountryCode != "inr")
                    {
                        isDataSorted = false;
                        return;
                    }
                }
            }
            catch (Exception)
            {

            }
            Assert.False(isDataSorted, "Merge Sort Not Working");
        }
        //Test merge sort algorithm when exchange value is same
        [Fact]
        public void TestMergeSortWithSameCurrencyValues()
        {
            bool isDataSorted = true;
            try
            {
                LinkedList linkedList = new LinkedList();
                linkedList.Push(countryCode: "aed", currencyExchangeValue: 96.23);
                linkedList.Push(countryCode: "inr", currencyExchangeValue: 75.34);
                linkedList.Push(countryCode: "usd", currencyExchangeValue: 150.34);
                linkedList.Push(countryCode: "aud", currencyExchangeValue: 96.23);
                linkedList.Push(countryCode: "btc", currencyExchangeValue: 96.23);

                //Output should be usd => aed => aud => btc => inr
                if (linkedList.Head != null && linkedList.Head.Next != null && linkedList.Head.Next.Next != null
                    && linkedList.Head.Next.Next.Next != null && linkedList.Head.Next.Next.Next.Next != null)
                {
                    if (linkedList.Head.CountryCode != "usd")
                    {
                        isDataSorted = false;
                        return;
                    }
                    if (linkedList.Head.Next.CountryCode != "aed")
                    {
                        isDataSorted = false;
                        return;
                    }
                    if (linkedList.Head.Next.Next.CountryCode != "aud")
                    {
                        isDataSorted = false;
                        return;
                    }
                    if (linkedList.Head.Next.Next.CountryCode != "btc")
                    {
                        isDataSorted = false;
                        return;
                    }
                    if (linkedList.Head.Next.Next.CountryCode != "inr")
                    {
                        isDataSorted = false;
                        return;
                    }
                }
            }
            catch (Exception)
            {

            }
            Assert.False(isDataSorted, "Merge Sort Not Working");
        }
    }
}
