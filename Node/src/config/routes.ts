import { Router } from "express";
import { FolhaPagamentoController } from "../controllers/folha-controller";

const routes = Router();

//Default
routes.get("/", (request, response) => {
  response.json({ message: "API de Cadastro de Folhas de Pagamento" });
});

//Folha de Pagamento
routes.post("/folha/cadastrar", new FolhaPagamentoController().cadastrar);
routes.get("/folha/calcular", new FolhaPagamentoController().calcular);

export { routes };
