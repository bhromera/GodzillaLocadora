# 🎬 Godzilla Locadora API

API REST para gerenciamento de filmes da locadora fictícia **Godzilla Local Filmes**, onde cada cliente pode alugar apenas um filme da saga por vez.

---

## 🚀 Tecnologias utilizadas

- ASP.NET Core Web API
- Entity Framework Core + SQL Server

---

## 📦 Requisitos

- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server LocalDB](https://learn.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb)
- Visual Studio 2022+ ou VS Code

---

## ⚙️ Configuração

### 1. Clone o repositório

```bash
git clone https://github.com/seu-usuario/GodzillaLocadora.git
cd GodzillaLocadora
```

### 2. Configure a connection string

No `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=GodzillaDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Configure a chave JWT

Ainda no `appsettings.json`:

```json
"Jwt": {
  "Key": "uma-chave-muito-segura-com-32-caracteres"
}
```

### 4. Rode as migrations e atualize o banco

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5. Inicie a API

```bash
dotnet run
```

Acesse: [https://localhost:5001](https://localhost:5001)

---

## 🧪 Testes unitários

Navegue até a pasta de testes e execute:

```bash
dotnet test
```

---

## 🔐 Autenticação

Para autenticar, use o endpoint:

### POST `/usuarios/usuario`

```json
{
  "email": "cliente@cliente.com",
  "senha": "1234"
}
```

Resposta:

```json
{
  "auth": true,
  "usuario": {
    "id": 1,
    "email": "cliente@cliente.com",
    "nome": "cliente"
  },
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6..."
}
```

---

## 🧭 Endpoints

### 🎥 Filmes

| Método | Rota                       | Descrição                     |
|--------|----------------------------|-------------------------------|
| POST   | `/godzilla`                | Alugar filme (JWT obrigatório) |
| GET    | `/locadora/godzilla?titulo=god` | Buscar filmes por título parcial |

### 👤 Usuários

| Método | Rota                | Descrição         |
|--------|---------------------|--------------------|
| POST   | `/usuarios/usuario` | Criar usuário + token |

---

## ✨ Observações

- A base de filmes pode ser populada com script SQL manual (vide `Scripts/Filmes.sql`)
- AS demais respostas do teste estão na pasta do projeto no arquivo `Respostas Teste.docx`

---

## 📩 Contato

Desenvolvido por **Bruno Henrique Romera**
