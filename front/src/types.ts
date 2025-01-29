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

  constructor(name: string,id:number) {
    this.name = name;
    this.id = id
  }

  static fromJson(content: Record<string, any>): CPower {
    return new CPower(content["name"],content["id"]);
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

  static fromJson(content: Record<string, any>): CHero {
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


export class CLocation {
    address: string;
    city: string;
    country: string;
    locationImage: string;
    googleFrame: string;
    isVirtual: boolean;

    constructor(
        address: string,
        city: string,
        country: string,
        locationImage: string = "",
        googleFrame: string = "",
        isVirtual: boolean = false
    ) {
        this.address = address;
        this.city = city;
        this.country = country;
        this.locationImage = locationImage;
        this.googleFrame = googleFrame;
        this.isVirtual = isVirtual;
    }

    static fromJson(content: Record<string, any>): CLocation {
        return new CLocation(
            content.address || "",
            content.city || "",
            content.country || "",
            content.locationImage || "",
            content.googleFrame || "",
            content.isVirtual || false
        );
    }
}

