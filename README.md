# 🏥 MediFlow - Gestão de Centro Cirúrgico

> MVP de um sistema de Agendamento Cirúrgico desenvolvido como estudo de caso para arquiteturas corporativas na área da saúde.

O **MediFlow** simula o *Core Business* de uma plataforma hospitalar: garantir que cirurgias sejam agendadas de forma eficiente, prevenindo conflitos de recursos (salas e horários) e garantindo a integridade dos dados clínicos.

---

## 🚀 Stack Tecnológica

O projeto foi construído alinhado com tecnologias robustas do mercado Enterprise:

- **Backend:** C# .NET 9.0 (Web API + Razor Pages)
- **Database:** Entity Framework Core (In-Memory para prototipação rápida)
- **Frontend:** Razor Pages (Server-Side Rendering) + jQuery/AJAX
- **UI:** Bootstrap 5

## 🏛️ Arquitetura & Padrões

O foco principal deste projeto não é apenas "funcionar", mas demonstrar organização e escalabilidade através de padrões de Engenharia de Software:

- **Arquitetura em Camadas (Layered Architecture):**
  - `Domain`: Entidades ricas e Regras de Negócio (DDD).
  - `Infra`: Implementação de persistência e Contexto de Banco.
  - `Web`: Controllers (API) e Pages (Frontend).
- **Repository Pattern:** Abstração do acesso a dados para desacoplar o domínio da tecnologia de banco.
- **Unit of Work:** Gerenciamento de transações para garantir atomicidade (ou salva a cirurgia completa, ou não salva nada).
- **Separation of Concerns:** DTOs para transferência de dados, impedindo exposição direta das Entidades na API.

## ⚡ Funcionalidades Atuais

- **Agendamento Inteligente:** Validação de regra de negócio que impede o agendamento de duas cirurgias na mesma sala em horários sobrepostos.
- **Visualização em Tempo Real:** Tabela dinâmica atualizada via AJAX sem recarregamento da página.
- **Validação de Domínio:** Entidades protegidas que impedem estados inconsistentes (ex: Data Fim menor que Data Início).

---

## 🔮 Roadmap de Inovação & AI (Future Contributions)

O próximo passo na evolução do MediFlow é a integração de **Inteligência Artificial Generativa (LLMs)** e **Análise Preditiva** para apoiar a decisão médica e administrativa:

### 1. Auditoria Pré-Cirúrgica com LLM
- **Objetivo:** Utilizar modelos de linguagem (como GPT-4 ou Gemini via Semantic Kernel no .NET) para analisar o histórico não estruturado do paciente.
- **Aplicação:** A IA leria as anotações médicas anteriores e alertaria no momento do agendamento sobre riscos ocultos, como: *"Atenção: Paciente alérgico a látex e a cirurgia agendada utilizará kit padrão."*

### 2. Otimização Preditiva de Salas (Smart Scheduling)
- **Objetivo:** Reduzir a ociosidade do centro cirúrgico.
- **Aplicação:** Implementar um algoritmo que analisa o histórico de cirurgias do médico X para o procedimento Y. Em vez de agendar o tempo padrão (ex: 2h), o sistema sugere o tempo real médio que aquele médico leva (ex: 1h15), liberando 45 minutos extras na agenda do hospital.

---

## 🛠️ Como Rodar

### Pré-requisitos
- .NET SDK 9.0
- Visual Studio 2022 ou VS Code

### Passo a Passo
1. Clone o repositório:
   ```bash
   git clone [https://github.com/rayfrance/medi-flow.git](https://github.com/rayfrance/medi-flow.git)
   ```
2. Abra a solução MediFlow.sln no Visual Studio.
3. Restaure os pacotes NuGet (o VS faz isso automaticamente ao compilar).
4. Execute o projeto (F5 ou botão Play).
5. O sistema abrirá no navegador padrão.

---

Desenvolvido como projeto de estudo prático focado em .NET, Arquitetura de Software e Inovação em Saúde.