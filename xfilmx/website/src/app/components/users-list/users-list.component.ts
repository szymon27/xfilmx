import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource, MatTableDataSourcePaginator } from '@angular/material/table';
import { User } from 'src/app/models/user';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent implements OnInit {
  users: MatTableDataSource<User>;
  @ViewChild('paginator') paginator: MatPaginator;

  constructor(private usersService: UsersService) {
    this.usersService.get().subscribe(res => {
      this.users = new MatTableDataSource(res);
      this.users.paginator = this.paginator;
      this.users.filterPredicate = (data: User, filter: string) => {
        return data.username.includes(filter);
      }
    });
  }

  ngOnInit(): void {
  }

  getImageSrc(user: User): any {
    if(user.picture != null)
      return 'data:image/png;base64,' + user.picture;
    return null;
  }

  onTypeChange(e: any, user: User): void {
    this.usersService.changeType(user.userId, e.value).subscribe(res => {
      if(res) {
        user.userType = e.value;
      }
    });
  }

  search(e: any): void {
    this.users.filter = (e as HTMLInputElement).value.toLowerCase();
  }
}