for i in `find /home/database/ -name "*.sql" | sort --version-sort`; do mysql -udocker -pdocker rest_ASPNET < $i; done;
