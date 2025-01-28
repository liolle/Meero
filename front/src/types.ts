export enum Role {
  User,
  Admin
}

export class UserSession {
  id:number
  name:string
  role:Role

  constructor(name:string,role:number,id:number){
    this.name = name
    role == 1 ? this.role = Role.Admin :this.role = Role.User 
    this.id = id
  }
}

export class CPower {
  id:number
  name: string
}

export class CHero {
  id:number
  name:string
  alias:string
  powers: Array<CPower>
}

