export type FolhaPagamento = {
  mes: number;
  ano: number;
  horas: number;
  valor: number;
  bruto: number;
  irrf: number;
  inss: number;
  fgts: number;
  liquido: number;
  funcionario: Funcionario;
};

type Funcionario = {
  nome: string;
  cpf: string;
};
