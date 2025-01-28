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

  constructor(name: string) {
    this.name = name;
  }

  static fromJson(content: Object): CPower {
    return new CPower(content["name"]);
  }
}

export class CHero {
  id:number
  name:string
  alias:string
  powers: Array<CPower>
  bio:string
  profileImage:string

  constructor(
    id: number,
    name: string,
    alias: string,
    powers: Array<CPower>,
    bio: string,
    profileImage: string
  ) {
    this.id = id;
    this.name = name;
    this.alias = alias;
    this.powers = powers;
    this.bio = bio;
    this.profileImage = profileImage;
  }

  static fromJson(content: Object): CHero {
    const powers = (content["powers"] || []).map((power: any) =>
      CPower.fromJson(power)
    );

    return new CHero(
      content["id"],
      content["name"],
      content["alias"],
      powers,
      content["bio"],
      content["profileImage"]
    );
  }
}

