# web-api-dot-net


dotnet ef

# Dentro do Infra

# Criar uma migration inicial

dotnet ef migrations add InitialCreation

# Aplicar as migrações no banco

dotnet ef database update

# Criar outra migration para adicionar alteracoes
dotnet ef migrations add <nome-migration>

dotnet ef database update
