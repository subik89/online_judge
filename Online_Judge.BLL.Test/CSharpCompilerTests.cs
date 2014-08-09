using Microsoft.VisualStudio.TestTools.UnitTesting;
using Online_Judge.BLL.Compilers.Impl;

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
			var result = new CSharpCompiler().Compile(@"using System;
            class Program {
              public static void Main(string[] args) {
				Console.WriteLine(3);
				Console.ReadKey();
              }
            }", "compile.exe");

			// Assert
			Assert.IsTrue(result);
		}
	}
}