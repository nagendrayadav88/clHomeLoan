import { Role } from './role';

export class User {
  id: number;
  img: string;
  username: string;
  password: string;
  firstName: string;
  lastName: string;
  roles: [string];
  token?: string;
}
