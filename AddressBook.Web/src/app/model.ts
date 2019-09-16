export class Address {
  id: string;
  address: string;
  lat: string;
  lon: string;
  userId: string;
  isVisible: boolean;
}

export class User {
  lastname: string;
  firstname: string;
  email: string;
  id: string;
  addresses: Array<Address>;

  constructor() {
    this.addresses = new Array<Address>();
  }
}
