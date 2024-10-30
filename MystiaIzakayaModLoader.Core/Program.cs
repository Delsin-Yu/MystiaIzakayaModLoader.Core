var portIndex = Array.FindIndex(args, arg =>
    arg.Equals("--port", StringComparison.OrdinalIgnoreCase)
    || arg.Equals("-p", StringComparison.OrdinalIgnoreCase));

if (portIndex == -1 || portIndex + 1 >= args.Length)
{
    Console.WriteLine("错误：未提供端口号(\'-p\'/\'--port\')");
    return;
}

var portCandidate = args[portIndex + 1];
if (!ushort.TryParse(portCandidate, out var port))
{
    Console.WriteLine($"错误：无法将\"{portCandidate}\"解析为端口！");
    return;
}

var builder = WebApplication.CreateSlimBuilder(args);

var app = builder.Build();

app.MapGet("check_connection", () => Results.Ok());

app.Run($"http://localhost:{port}/");