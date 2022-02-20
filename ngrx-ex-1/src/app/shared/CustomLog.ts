export interface ICustomLog {
 info(message: string) : void,
 error(message: string): void,
 message(message: string) : void
}


export class CustomLog implements ICustomLog {
  info(message: string): void {
   console.log(message)
  }
  error(message: string): void {
    console.log(message)
  }
  message(message: string): void {
    console.log(message)
  }

 }
