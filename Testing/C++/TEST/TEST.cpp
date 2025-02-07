#include <bits\stdc++.h>

using namespace std;


int main() {
    ios_base::sync_with_stdio(false);
    cin.tie(nullptr);
    int n,m;
    cin >> n>>m;
    vector<int>arr(n);
    vector<int>arr2;
    for (int i = 0; i < n; i++) { 
        cin >> arr[i];
        if (arr[i] <= m || arr[i] >= -m) {
            arr2.push_back(arr[i]);
        }
    }
    for (int i = 0; i < arr2.size(); i++) {
       
    
    }
    
}