using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    public class Question1
    {
        public TreeNode CreateBinaryTree(List<int> list)
        {
            if (list == null || list.Count == 0 || list[0] == null)
                return null;
            TreeNode root = new TreeNode(list[0]);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int index = 1;
            while (index < list.Count)
            {
                TreeNode current = queue.Dequeue();

                if (list[index]!=-1)
                {
                    current.Left = new TreeNode(list[index]);
                    queue.Enqueue(current.Left);
                }
                index++;

                if (index < list.Count && list[index]!=-1)
                {
                    current.Right = new TreeNode(list[index]);
                    queue.Enqueue(current.Right);
                }
                index++;
            }
            return root;
        }
        public async Task<int> MinDepthAsync(List<int> list)
        {
            TreeNode root=await Task.Run(()=>CreateBinaryTree(list));
            if (root == null)
            {
                return 0;
            }
            return await FindDept(root);
            
        }
        public async Task<int> FindDept(TreeNode root)
        {
            if(root.Left == null && root.Right == null)
            {
                return 1;
            }
            if (root.Left == null)
            {
                return await FindDept(root.Right)+1;
            }
            if (root.Right == null)
            {
                return await FindDept(root.Left)+1;
            }

            return Math.Min(await FindDept(root.Right),await FindDept(root.Left))+1;  
        }

                    
        static void Main(string[] args)
        {
            List<int> input = new List<int>() { 3, 9, 20, -1, -1, 15, 7};
            input = new List<int>() { 2, -1, 3, -1, 4, -1, 5, -1, 6 };
            Question1 question1 = new Question1();
            Task <int> res = Task.Run(() => question1.MinDepthAsync(input));
            Console.WriteLine(res.Result);
            Console.WriteLine((int)27 / 26);
            


        }
    }
}
