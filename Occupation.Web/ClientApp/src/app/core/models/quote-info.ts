import { NgbDateStruct } from "@ng-bootstrap/ng-bootstrap";

export class QuoteInfo {
  constructor(
    public quoteId: number = 0,
    public name: string,
    public occupationId: number,
    public dateOfBirth: string,
    public age: number,
    public coverAmount: number
  ) {}
}
