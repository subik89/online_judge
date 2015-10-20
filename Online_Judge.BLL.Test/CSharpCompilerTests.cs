﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineJudge.Infrastructure._Impl;
using Online_Judge.BLL.Compilers._Impl;

namespace Online_Judge.BLL.Test
{
	/// <summary>
	/// CSharpCompilerTests class
	/// </summary>
	[TestClass]
	public class CSharpCompilerTests
	{
		[TestMethod]
		public void CompileTest()
		{
			// Act
			var result = new CSharpCodeCompilerStrategy(new FileSystemService()).Compile(@"using System;
            class Program {
              public static void Main(string[] args) {
				Console.WriteLine(3);
              }
            }", "compile.exe", "C:\temp");

			// Assert
			Assert.IsTrue(result);
		}
	}
}