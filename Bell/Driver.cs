using System;
using System.Runtime.Remoting.Messaging;

using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;

namespace Quantum.Bell
{
    class Driver
    {
        static void Main(string[] args)
        {
            // The C# driver has four parts:+
            // Construct a quantum simulator. In the example, sim is the simulator.
            // Compute any arguments required for the quantum algorithm.In the example, count is fixed at a 1000 and initial is the initial value of the qubit.
            // Run the quantum algorithm. Each Q# operation generates a C# class with the same name. This class has a Run method that asynchronously executes the operation.
            // The execution is asynchronous because execution on actual hardware will be asynchronous.
            // Because the Run method is asynchronous, we fetch the Result property; this blocks execution until the task completes and returns the result synchronously.
            // Process the result of the operation. In the example, res receives the result of the operation.
            // Here the result is a tuple of the number of zeros(numZeros) and number of ones(numOnes) measured by the simulator.
            // This is returned as a ValueTuple in C#. We deconstruct the tuple to get the two fields, print the results, and then wait for a keypress.
            using (var sim = new QuantumSimulator())
            {
                // Try initial values
                Result[] initals = new Result[] {Result.Zero, Result.One};
                foreach (Result initial in initals)
                {
                    var res = BellTest.Run(sim, 1000, initial).Result;
                    var (numZeros, numOnes, agree) = res;
                    Console.WriteLine($"Init: {initial, -4} 0s={numZeros, -4} 1s={numOnes, -4} agree={agree, -4}");
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}