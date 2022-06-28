import axios from "axios";
import { Request, Response } from "express";
import { FolhaPagamento } from "../models/folha-pagamento";
import { FolhaRepositoryQueue } from "../repositories/folha-repository-queue";
import { FolhaRepository } from "../repositories/folha-repository.";

const folhaRepository = new FolhaRepository();

export class FolhaPagamentoController {
  cadastrar(request: Request, response: Response) {
    const folha: FolhaPagamento = request.body;
    const folhas = folhaRepository.cadastrar(folha);
    return response.status(201).json(folhas);
  }

  async calcular(request: Request, response: Response) {
    let folhas: FolhaPagamento[] = folhaRepository.listar();

    //Processar as folhas e enviar para a aplicação B
    folhas.map((folha) => {
      folha.bruto = folha.horas * folha.valor,
      folha.irrf = calcularIRRF(folha.bruto);
      folha.inss = calcularINSS(folha.bruto);
      folha.fgts = calcularFGTS(folha.bruto);
      folha.liquido = calcularSalarioLiquido(folha.bruto, folha.irrf, folha.inss);
    });

    const server = new FolhaRepositoryQueue('amqp://localhost');

    await server.start();

    await server.publishInQueue('mensagem', JSON.stringify(folhas));
  }

}

function calcularSalarioBruto(horas: number, valor: number): number {
  console.log("TEste");
  return horas * valor;
}

function calcularIRRF(bruto: number): number {
  if (bruto <= 1903.98) {
    return 0;
  } else if (bruto <= 2826.65) {
    return bruto * 0.075 - 142.8;
  } else if (bruto <= 3751.05) {
    return bruto * 0.15 - 354.8;
  } else if (bruto <= 4664.68) {
    return bruto * 0.225 - 636.13;
  }
  return bruto * 0.275 - 869.39;
}

function calcularINSS(bruto: number): number {
  if (bruto <= 1693.72) {
    return bruto * 0.08;
  } else if (bruto <= 2822.9) {
    return bruto * 0.09;
  } else if (bruto <= 5645.8) {
    return bruto * 0.11;
  }
  return 621.03;
}

function calcularFGTS(bruto: number): number {
  return bruto * 0.08;
}

function calcularSalarioLiquido(bruto: number, irrf: number, inss: number): number {
  return bruto - irrf - inss;
}
