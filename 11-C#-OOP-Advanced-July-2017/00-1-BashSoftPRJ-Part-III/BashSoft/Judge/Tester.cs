using BashSoft.Exceptions;
using System;
using System.IO;
using BashSoft.Contracts;

namespace BashSoft
    {
    public class Tester : IContentComparer
        {
        public void CompareContent(string userOutputPath, string expectedOutputPath)
            {
            OutputWriter.WriteMessageOnNewLine("Reading files ...");
            try
                {
                string mismatchPath = GetMismatchPath(expectedOutputPath);

                string[] actualOutputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

                bool hasMismatch;
                string[] mismatches = GetLineWithPossibleMismatches(actualOutputLines, expectedOutputLines, out hasMismatch);

                PrintOutput(mismatches, hasMismatch, mismatchPath);
                OutputWriter.WriteMessageOnNewLine("Files read!");
                }
            catch (IOException)
                {
                throw new InvalidPathException();
                }
            }

        private string[] GetLineWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
            {
            hasMismatch = false;
            string output = String.Empty;

            OutputWriter.WriteMessageOnNewLine("Comparing files ...");

            // add f04 - p02
            int minOutputLines = actualOutputLines.Length;
            if (actualOutputLines.Length != expectedOutputLines.Length)
                {
                hasMismatch = true;
                minOutputLines = Math.Min(actualOutputLines.Length, expectedOutputLines.Length);
                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
                }
            // Move from above f04-p-02
            string[] mismatches = new string[minOutputLines];

            for (int index = 0; index < minOutputLines; index++)
                {
                string actualLine = actualOutputLines[index];
                string expectedLine = expectedOutputLines[index];

                if (!actualLine.Equals(expectedLine))
                    {
                    output = string.Format("Mismatch at line {0} -- expected: \"{1}\", actual: \"{2}\"", index, expectedLine, actualLine);
                    output += Environment.NewLine;
                    hasMismatch = true;
                    }
                else
                    {
                    output = actualLine;
                    output += Environment.NewLine;
                    }

                mismatches[index] = output;
                }

            return mismatches;
            }

        private string GetMismatchPath(string expectedOutputPath)
            {
            int indexOf = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = directoryPath + @"Mismatches.txt";

            return finalPath;
            }

        private void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
            {
            if (hasMismatch)
                {
                foreach (var line in mismatches)
                    {
                    OutputWriter.WriteMessageOnNewLine(line);
                    }

                // f04-p05
                File.WriteAllLines(mismatchPath, mismatches);
                }
            else
                {
                OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
                }

            return;
            }
        } // END of class TESTER
    }