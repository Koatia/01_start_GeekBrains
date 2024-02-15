clear
mkdir git-merge-test
cd git-merge-test
git init .
echo "this is some content to mess with" > merge.txt
git add merge.txt
git commit -am"we are commiting the inital content"
git branch new_branch_to_merge_later
git checkout new_branch_to_merge_later
echo "totally different content to merge later" > merge.txt
git commit -am"edited the content of merge.txt to cause a conflict"
git status
git checkout master
echo "content to append" >> merge.txt
git commit -am"appended content to merge.txt"
git status
git log --oneline --graph
git merge new_branch_to_merge_later
