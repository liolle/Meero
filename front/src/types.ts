export enum Role {
  User,
  Admin
}

export class UserSession {
  name:string
  role:Role
  id:number

  constructor(name:string,role:number,id:number){
    this.name = name
    role == 1 ? this.role = Role.Admin :this.role = Role.User 
    this.id = id
  }
}

