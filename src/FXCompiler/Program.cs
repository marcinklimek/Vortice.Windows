using Vortice.D3DCompiler;
using System.Text.RegularExpressions;

string PreprocessShader(string shaderPath)
{
    var shaderCode = File.ReadAllText(shaderPath);
    var includeRegex = new Regex("#include \"(.*?)\"");
    var matches = includeRegex.Matches(shaderCode);

    var root = Path.GetDirectoryName(shaderPath) ?? string.Empty;


    foreach (Match match in matches)
    {
        var includePath = Path.Combine(root, match.Groups[1].Value);

        if (includePath == string.Empty) 
            continue;
        
        Console.WriteLine($" - combining: {includePath}");

        var includeCode = File.ReadAllText(includePath);
        shaderCode = shaderCode.Replace(match.Value, includeCode);
    }
    
    return shaderCode;
}

Console.WriteLine("FX Compiler v3.5.2\n");


if (args.Length == 0)
{
    Console.WriteLine("Usage:\n fxCompiler.exe <shader.fx>\n");
    Console.WriteLine("The compiler always overwrites the output.");
    return;
}


Console.WriteLine($"Processing: {args[0]}" );

var shaderPath = args[0];
var tempCombinedShaderPath = Path.GetTempFileName();
var compiledOutputPath = Path.Combine(Path.GetDirectoryName(shaderPath) ?? string.Empty, $"{Path.GetFileNameWithoutExtension(shaderPath)}.fxo");


if (File.Exists(shaderPath))
{
    var stream = PreprocessShader(shaderPath);
    File.WriteAllText(tempCombinedShaderPath, stream);
}

var effectByteCode = Compiler.CompileFromFile(tempCombinedShaderPath, string.Empty, "fx_5_0", ShaderFlags.None, EffectFlags.None);
File.WriteAllBytes(compiledOutputPath, effectByteCode.ToArray());

Console.WriteLine($"Output file: {compiledOutputPath}\n");
Console.WriteLine("Finished.");
