let name = "Alice"
let json = $$"""
    {
    "user": "{{name}}",
    "message": "Hello, {{" + name + "}}!",
    "secondMessage": "Hello, {{name}}!",
    "age": {{ 30 + 5 }}
    }
    """
printfn $"{json}"
